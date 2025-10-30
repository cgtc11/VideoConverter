using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoConverter
{
    public partial class Form1 : Form
    {
        private List<Process> ffmpegProcesses = new List<Process>();
        private List<string> generatedGifFiles = new List<string>();

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            chkGenerateHtml.Enabled = chkOutputGif.Checked;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtFolderPath.Text = fbd.SelectedPath;
                }
            }
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFolderPath.Text) || !Directory.Exists(txtFolderPath.Text))
                {
                    MessageBox.Show("フォルダを選択してください。");
                    return;
                }

                if (!chkOutputGif.Checked && chkGenerateHtml.Checked)
                {
                    MessageBox.Show("GIF出力が無効の場合、HTML生成はできません。");
                    return;
                }

                var searchOption = chkIncludeSubfolders.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                var files = Directory.GetFiles(txtFolderPath.Text, "*.*", searchOption)
                                     .Where(s => s.EndsWith(".avi", StringComparison.OrdinalIgnoreCase)
                                              || s.EndsWith(".mov", StringComparison.OrdinalIgnoreCase)
                                              || s.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase))
                                     .ToArray();

                if (files.Length == 0)
                {
                    MessageBox.Show("選択されたフォルダに対象ファイルがありません。");
                    return;
                }

                progressBar.Maximum = files.Length;
                progressBar.Value = 0;

                generatedGifFiles.Clear();

                // 実行開始時に中止ボタンを有効にする
                btnCancel.Enabled = true;

                foreach (var file in files)
                {
                    // 中止ボタンが押されたら止める
                    if (!btnCancel.Enabled)
                        break;

                    if (chkOutputMp4.Checked)
                    {
                        if (rbtnSameFrames.Checked)
                        {
                            await ConvertTo30FpsSameFrames(file);
                        }
                        else if (rbtnSameDuration.Checked)
                        {
                            await ConvertTo30FpsSameDuration(file);
                        }
                    }

                    if (chkOutputGif.Checked)
                    {
                        await ConvertToGif(file);
                    }

                    if (chkOutputPngSeq.Checked)
                    {
                        await ConvertToPngSequence(file);
                    }

                    progressBar.Value++;
                }

                btnCancel.Enabled = false;

                if (chkGenerateHtml.Checked)
                {
                    GenerateHtml();
                }

                MessageBox.Show("変換が終了しました。");
            }
            catch (Exception ex)
            {
                btnCancel.Enabled = false;
                MessageBox.Show($"エラーが発生しました: {ex.Message}");
            }
        }

        private Task ConvertTo30FpsSameFrames(string filePath)
        {
            return Task.Run(() =>
            {
                try
                {
                    string directory = Path.GetDirectoryName(filePath);
                    string newDirectory = Path.Combine(directory, "_30fpsMP4");

                    if (!Directory.Exists(newDirectory))
                    {
                        Directory.CreateDirectory(newDirectory);
                    }

                    string filenameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                    string newFilePath = Path.Combine(newDirectory, filenameWithoutExtension + "_30fps.mp4");

                    var startInfo = new ProcessStartInfo
                    {
                        FileName = "ffmpeg.exe",
                        // 最初の形に戻す。コーデック指定なし。30fps＋setptsだけ。
                        Arguments = $"-y -i \"{filePath}\" -r 30 -filter:v \"setpts=PTS*0.8\" \"{newFilePath}\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    var process = new Process { StartInfo = startInfo };
                    lock (ffmpegProcesses)
                    {
                        ffmpegProcesses.Add(process);
                    }

                    process.OutputDataReceived += (sender, args) => Debug.WriteLine(args.Data);
                    process.ErrorDataReceived += (sender, args) => Debug.WriteLine(args.Data);

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    process.WaitForExit();

                    lock (ffmpegProcesses)
                    {
                        ffmpegProcesses.Remove(process);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"エラーが発生しました: {ex.Message}");
                }
            });
        }

        private Task ConvertTo30FpsSameDuration(string filePath)
        {
            return Task.Run(() =>
            {
                try
                {
                    string directory = Path.GetDirectoryName(filePath);
                    string newDirectory = Path.Combine(directory, "_30fpsMP4");

                    if (!Directory.Exists(newDirectory))
                    {
                        Directory.CreateDirectory(newDirectory);
                    }

                    string filenameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                    string newFilePath = Path.Combine(newDirectory, filenameWithoutExtension + "_30fps.mp4");

                    var startInfo = new ProcessStartInfo
                    {
                        FileName = "ffmpeg.exe",
                        // 同じく最初の形に戻す
                        Arguments = $"-y -i \"{filePath}\" -vf \"fps=30\" -vsync vfr \"{newFilePath}\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    var process = new Process { StartInfo = startInfo };
                    lock (ffmpegProcesses)
                    {
                        ffmpegProcesses.Add(process);
                    }

                    process.OutputDataReceived += (sender, args) => Debug.WriteLine(args.Data);
                    process.ErrorDataReceived += (sender, args) => Debug.WriteLine(args.Data);

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    process.WaitForExit();

                    lock (ffmpegProcesses)
                    {
                        ffmpegProcesses.Remove(process);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"エラーが発生しました: {ex.Message}");
                }
            });
        }

        private Task ConvertToGif(string filePath)
        {
            return Task.Run(() =>
            {
                try
                {
                    string directory = Path.GetDirectoryName(filePath);
                    string newDirectory = Path.Combine(directory, "_GifAnim");

                    if (!Directory.Exists(newDirectory))
                    {
                        Directory.CreateDirectory(newDirectory);
                    }

                    string filenameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                    string newFilePath = Path.Combine(newDirectory, filenameWithoutExtension + "_30fps.gif");

                    double scale;
                    if (!double.TryParse(txtGifScale.Text, out scale) || scale <= 0)
                    {
                        MessageBox.Show("有効な倍率を入力してください。");
                        return;
                    }

                    var startInfo = new ProcessStartInfo
                    {
                        FileName = "ffmpeg.exe",
                        Arguments = $"-y -i \"{filePath}\" -vf \"scale=iw*{scale}:ih*{scale}\" \"{newFilePath}\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    var process = new Process { StartInfo = startInfo };
                    lock (ffmpegProcesses)
                    {
                        ffmpegProcesses.Add(process);
                    }

                    process.OutputDataReceived += (sender, args) => Debug.WriteLine(args.Data);
                    process.ErrorDataReceived += (sender, args) => Debug.WriteLine(args.Data);

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    process.WaitForExit();

                    lock (ffmpegProcesses)
                    {
                        ffmpegProcesses.Remove(process);
                    }

                    generatedGifFiles.Add(newFilePath);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"エラーが発生しました: {ex.Message}");
                }
            });
        }

        private Task ConvertToPngSequence(string filePath)
        {
            return Task.Run(() =>
            {
                try
                {
                    string directory = Path.GetDirectoryName(filePath);
                    string baseDirectory = Path.Combine(directory, "_PngSeq");
                    if (!Directory.Exists(baseDirectory))
                    {
                        Directory.CreateDirectory(baseDirectory);
                    }

                    string filenameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                    string perFileDirectory = Path.Combine(baseDirectory, filenameWithoutExtension);
                    if (!Directory.Exists(perFileDirectory))
                    {
                        Directory.CreateDirectory(perFileDirectory);
                    }

                    string outputPattern = Path.Combine(perFileDirectory, filenameWithoutExtension + "_%04d.png");

                    var startInfo = new ProcessStartInfo
                    {
                        FileName = "ffmpeg.exe",
                        Arguments = $"-y -i \"{filePath}\" -vf \"fps=30\" \"{outputPattern}\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    var process = new Process { StartInfo = startInfo };
                    lock (ffmpegProcesses)
                    {
                        ffmpegProcesses.Add(process);
                    }

                    process.OutputDataReceived += (sender, args) => Debug.WriteLine(args.Data);
                    process.ErrorDataReceived += (sender, args) => Debug.WriteLine(args.Data);

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    process.WaitForExit();

                    lock (ffmpegProcesses)
                    {
                        ffmpegProcesses.Remove(process);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"エラーが発生しました: {ex.Message}");
                }
            });
        }

        private void GenerateHtml()
        {
            try
            {
                string directory = txtFolderPath.Text;
                string htmlFilePath = Path.Combine(directory, "_index.html");

                using (StreamWriter writer = new StreamWriter(htmlFilePath))
                {
                    writer.WriteLine("<html>");
                    writer.WriteLine("<head><title>素材一覧</title></head>");
                    writer.WriteLine("<body>");
                    writer.WriteLine("<h1>素材一覧</h1>");
                    writer.WriteLine("<div style=\"display: flex; flex-wrap: wrap;\">");

                    foreach (var gifFile in generatedGifFiles)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(gifFile);
                        string relativePath = MakeRelativePath(htmlFilePath, gifFile);
                        string subdirectory = Path.GetDirectoryName(relativePath);
                        string displayName = subdirectory == "_GifAnim" ? fileName : $"{subdirectory}\\{fileName}";

                        writer.WriteLine($"<div style=\"margin: 10px; text-align: center;\">");
                        writer.WriteLine($"<img src=\"{relativePath}\" alt=\"{fileName}\" style=\"max-width: 200px;\"><br>");
                        writer.WriteLine($"<span>{displayName}</span>");
                        writer.WriteLine("</div>");
                    }

                    writer.WriteLine("</div>");
                    writer.WriteLine("</body>");
                    writer.WriteLine("</html>");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"HTML生成中にエラーが発生しました: {ex.Message}");
            }
        }

        private static string MakeRelativePath(string fromPath, string toPath)
        {
            Uri fromUri = new Uri(fromPath);
            Uri toUri = new Uri(toPath);

            if (fromUri.Scheme != toUri.Scheme) { return toPath; }

            Uri relativeUri = fromUri.MakeRelativeUri(toUri);
            string relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            if (toUri.Scheme.Equals("file", StringComparison.InvariantCultureIgnoreCase))
            {
                relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            }

            return relativePath;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopAllFfmpeg();
        }

        private void chkOutputGif_CheckedChanged(object sender, EventArgs e)
        {
            chkGenerateHtml.Enabled = chkOutputGif.Checked;
        }

        private void chkOutputMp4_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkOutputPngSeq_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            StopAllFfmpeg();
            btnCancel.Enabled = false;
        }

        private void StopAllFfmpeg()
        {
            lock (ffmpegProcesses)
            {
                foreach (var p in ffmpegProcesses.ToList())
                {
                    try
                    {
                        if (!p.HasExited)
                            p.Kill();
                    }
                    catch { }
                }
                ffmpegProcesses.Clear();
            }
        }
    }
}
