# Blazor MixTemplate

## これは何

BlazorClientとBlazorServerの共通テンプレート  
preview8 時点の両方のテンプレートの機能をまとめ、それぞれのプロジェクトファイルを開くことで ServerとClientを切り替えて実行できる。  
ファイルは共通だがServerとClientでの処理の差分を #if で切り替えられるよう差分を整理したもの

## 何のためか

BlazorClientはVisual Studioのデバッガが使えないが、BlazorServerは普通にデバッガが使える。  
開発目的がBlazorClientであっても、BlazorServerで開発を行なったほうが楽が出来る。

## 差異

### ビルド

当然ながら生成物が違う。それぞれのプロジェクトファイルに差異が生じる  
デフォルトの名前空間がプロジェクトファイル名で決まるので明示的に書いておく。

### 使用しないファイル

BlazorServer は ASP.NET Coreとして必要なファイルがあるが、Clientには不要。  
_host.cshtmlはClientにおけるwwwroot/index.html相当。  
Blazor.webassembly.js と blazor.server.js の差異などがある。

* appsettings.json
* Pages/_Host.cshtml

これらはClientのプロジェクトファイルから除外対象にしておく。  
Server 側で index.htmlはあっても悪さはしないが、気になるなら除外対象にする。  
このあたりのファイルでJavaScriptを読み込ませておくなら、_Host.cshtmlとindex.html両方に書く必要がある。

### Startup/Programクラス

初期化関連はいろいろ違う  
差異は #if で区別しておく。

### App.razor 

Router に指定するアセンブリの差異  
単一のアセンブリで作っていれば関係ないような気もするが念の為

### HttpClient

Client は DI からBaseAddressの入った HttpClientが手に入るので、何も考えなくていい。  
Serverはもらえないので、自サーバーのファイルを覗いたり、APIたたくのにも手間がかかる。  
Pages/FetchData_c.razor に対応サンプル
