ffmpeg.exe が122Mあってはいらなかったので入れてない</br>
</br>
<h1>動画一括変換ツール（30fps / GIF / PNG連番）取扱説明</h1>

<p><strong>対応OS:</strong> Windows（.NET / WinForms）<br>
<strong>必須:</strong> このアプリと同じ場所に <code>ffmpeg.exe</code> があること</p>

<hr>

<h2>目次</h2>
<ol>
  <li><a href="#what-you-can-do">できること</a></li>
  <li><a href="#requirements">動作条件</a></li>
  <li><a href="#ui">画面と各項目</a></li>
  <li><a href="#outputs">出力先とファイル名</a></li>
  <li><a href="#flow">処理の流れ</a></li>
  <li><a href="#faq">よくある質問</a></li>
  <li><a href="#notes">注意点</a></li>
</ol>

<hr>

<h2 id="what-you-can-do">1. できること</h2>
<p>指定フォルダ（必要に応じてサブフォルダも含む）内の動画をまとめて変換します。対象拡張子は <code>.avi</code> / <code>.mov</code> / <code>.mp4</code> です。実行時にONにした項目だけ処理します。</p>

<ul>
  <li><strong>MP4を30fpsで書き出し</strong><br>
    同じフレーム数／同じ時間長 の2モードで30fps化してMP4出力（コーデック指定なし＝ffmpegデフォルト）。<br>
    出力先: <code>_30fpsMP4</code> フォルダ
  </li>
  <li><strong>GIFアニメ出力</strong><br>
    倍率（例: 0.2 = 20%）を指定してGIFを書き出し。<br>
    出力先: <code>_GifAnim</code> フォルダ
  </li>
  <li><strong>連番PNG出力（デフォルトON）</strong><br>
    30fps固定でPNG連番を書き出し。動画ごとにサブフォルダを掘って保存。<br>
    出力先: <code>_PngSeq/&lt;元ファイル名&gt;/&lt;元ファイル名&gt;_0001.png</code> …
  </li>
  <li><strong>HTMLギャラリー</strong><br>
    GIF出力がONのとき、変換後に <code>_index.html</code> を作成（GIFの簡易一覧）。
  </li>
</ul>

<hr>

<h2 id="requirements">2. 動作条件</h2>
<ul>
  <li>Windows（.NET / WinForms アプリ）</li>
  <li><code>ffmpeg.exe</code> がアプリ実行ファイルと同じフォルダにあること</li>
</ul>

<hr>

<h2 id="ui">3. 画面と各項目</h2>

<h3>フォルダ選択</h3>
<ul>
  <li>「フォルダ選択」ボタンで処理対象の親フォルダを指定。</li>
  <li>テキストボックスにパスが表示されます。</li>
</ul>

<h3>サブフォルダを含む</h3>
<ul>
  <li>ON: 下位フォルダもすべて走査。</li>
  <li>OFF: 現在の階層のみ対象。</li>
</ul>

<h3>進行状況バー</h3>
<ul>
  <li>検出した動画の本数を上限として1本処理するごとに進みます。</li>
</ul>

<h3>30fpsのそろえ方（MP4出力に適用）</h3>
<ul>
  <li><strong>同じフレーム数</strong>：フレーム数優先で30fps化（<code>setpts</code>使用）。</li>
  <li><strong>同じ時間長</strong>：再生時間優先で30fps化（<code>fps=30</code> / <code>-vsync vfr</code>）。</li>
</ul>

<h3>出力項目</h3>
<ul>
  <li><strong>MP4を出力</strong>：ONのときのみ <code>_30fpsMP4</code> に <code>_30fps.mp4</code> を作成。</li>
  <li><strong>GIFを出力</strong>：ONのときのみ <code>_GifAnim</code> に <code>_30fps.gif</code> を作成。</li>
  <li><strong>HTMLを生成する</strong>：GIF出力がONのときだけ有効。変換後に <code>_index.html</code> を作成。</li>
  <li><strong>連番PNG書き出し</strong>：<u>デフォルトON</u>。30fpsでPNG連番を <code>_PngSeq/&lt;元名&gt;/</code> に出力。</li>
</ul>

<h3>GIF倍率</h3>
<ul>
  <li>例：<code>0.2</code> = 20%縮小、<code>1.0</code> = 等倍。</li>
  <li>0以下はエラーになります。</li>
</ul>

<h3>実行 / 中止</h3>
<ul>
  <li><strong>実行</strong>：選択した全動画を順次処理します。</li>
  <li><strong>中止</strong>：変換中のみ押せます。内部で実行中の ffmpeg を停止します（ここまでの成果物は残ります）。</li>
</ul>

<hr>

<h2 id="outputs">4. 出力先とファイル名</h2>

<table>
  <thead>
    <tr>
      <th>種別</th>
      <th>出力先</th>
      <th>ファイル名</th>
      <th>補足</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>MP4</td>
      <td><code>元フォルダ/_30fpsMP4/</code></td>
      <td><code>元名_30fps.mp4</code></td>
      <td>ffmpegデフォルトのエンコード設定</td>
    </tr>
    <tr>
      <td>GIF</td>
      <td><code>元フォルダ/_GifAnim/</code></td>
      <td><code>元名_30fps.gif</code></td>
      <td>倍率は「GIF倍率」で指定</td>
    </tr>
    <tr>
      <td>PNG連番</td>
      <td><code>元フォルダ/_PngSeq/元名/</code></td>
      <td><code>元名_0001.png</code>, <code>元名_0002.png</code> …</td>
      <td>4桁ゼロ埋め（<code>%04d</code>）/ 30fps固定</td>
    </tr>
    <tr>
      <td>HTML</td>
      <td><code>元フォルダ/_index.html</code></td>
      <td>—</td>
      <td>GIFの簡易サムネイル一覧</td>
    </tr>
  </tbody>
</table>

<hr>

<h2 id="flow">5. 処理の流れ</h2>
<ol>
  <li>「フォルダ選択」で親フォルダを指定。</li>
  <li>必要なチェック（MP4/GIF/PNG/HTML、サブフォルダ）を設定。</li>
  <li>「実行」を押すと、検出した動画を1本ずつ処理。</li>
  <li>各項目がONの場合のみ出力（順番：MP4 → GIF → PNG）。</li>
  <li>GIF＋HTMLがONなら最後に <code>_index.html</code> を生成。</li>
  <li>「中止」を押すと、その時点で ffmpeg を停止。</li>
</ol>

<hr>

<h2 id="faq">6. よくある質問</h2>

<h3>Q. MP4が出力されない</h3>
<p>
  現在はコーデック指定を行わず ffmpeg のデフォルトに任せています。以下を確認してください：
</p>
<ul>
  <li><code>ffmpeg.exe</code> がアプリと同じフォルダにある</li>
  <li>出力先フォルダに書き込み権限がある</li>
  <li>入力ファイルに問題がない（破損など）</li>
</ul>
<p>コマンドプロンプトで <code>ffmpeg -version</code> が動作するかも確認してください。</p>

<h3>Q. PNGを別ドライブに出したい</h3>
<p>
  現状は「元動画と同じ場所に <code>_PngSeq</code>」固定です。出力先を変えたい場合はUI項目の追加が必要です。
</p>

<h3>Q. PNGを続き番号で追加したい</h3>
<p>
  今は <code>_0001.png</code> から再生成（<code>-y</code> により上書き）です。続き番号にするには既存番号の最大値を検出する処理が必要です。
</p>

<h3>Q. GIFをより綺麗にしたい</h3>
<p>
  パレット作成＆2pass（<code>palettegen</code> / <code>paletteuse</code>）を組み込むと改善します。必要なら実装可能です。
</p>

<hr>

<h2 id="notes">7. 注意点</h2>
<ul>
  <li>同名出力は上書きされます。バックアップが必要な場合は事前にコピーしてください。</li>
  <li>大きい動画や大量のファイルは時間がかかります。途中で止めたい場合は「中止」を押してください。</li>
  <li>アプリ終了時は内部の ffmpeg を停止するようにしていますが、まれにプロセスが残る場合があります。必要に応じてタスクマネージャーで確認してください。</li>
</ul>

<hr>

<h2>参考（内蔵の ffmpeg 呼び出し方の概念）</h2>
<details>
  <summary>クリックで開く</summary>
  <pre><code>MP4（同じフレーム数）
ffmpeg -y -i "入力" -r 30 -filter:v "setpts=PTS*0.8" "出力/_30fpsMP4/元名_30fps.mp4"

MP4（同じ時間長）
ffmpeg -y -i "入力" -vf "fps=30" -vsync vfr "出力/_30fpsMP4/元名_30fps.mp4"

GIF
ffmpeg -y -i "入力" -vf "scale=iw*{倍率}:ih*{倍率}" "出力/_GifAnim/元名_30fps.gif"

PNG連番（30fps固定）
ffmpeg -y -i "入力" -vf "fps=30" "出力/_PngSeq/元名/元名_%04d.png"
</code></pre>
</details>
