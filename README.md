# Doodle-DrawTogether
同じテーマを基にして一緒に自分の落書き作品を作りましょ！
<br/>
<b>このゲームは、ニフティクラウドmobile backendのサンプルです。</b>
<br/><br/>
<img width="400px" src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/100.jpg"/>
<img width="400px" src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/101.jpg"/>
<img width="400px" src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/102.jpg"/>
<img width="400px" src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/103.jpg"/>
<h2 id="contents">コンテンツ概要</h2>
<ul>
  <li><b>ニフティクラウドmobile backend（下記mb）の説明</b>
    <ul>
      <li>このゲームでは、mbの「会員管理」、「データストア」、「ファイルストア」の三つの機能を使っています。
      	この三つの機能を、このドキュメントに説明します。
      </li>
    </ul>
  </li>
</ul>
<p><img width="400px" src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/3functions.jpg"/></p>
<ul>
  <li><b>ゲーム内容の説明</b>
    <ul>
      <li>このゲームでは、ユーザーがテーマとしての簡単の線を書くことが出来る、そして、テーマを基にして、自分の落書き作品を書くことも出来ます。最も人気高い落書きは、本日ベストになります。（簡単なランキング機能付）</li>
      <li>以上のゲーム機能を、このドキュメントに説明します。 </li>
    </ul>
  </li>
  <li><b>ディスカッションについて</b>
	  <ul>
	  	<li>このドキュメントに、技術を実践に応用するため、ディスカッション問題を提供しています。
	  	コードを見ながら、是非御自身も試して下さい！</li>
	  	<li>質問の答えは全部プロジェクトのコードにあります。答えを探す方法は<a href="#discussionanswer">こちら</a>。</li>
	  </ul>
  </li>
  <li><b>開発者として、mbの便利さを利用しながら、
  <br/>ゲームプレーヤーとしての嬉しさも楽しもう！</b></li>
</ul>
<h2 id="keyquestion">キー問題</h2>
<ul>
  <li><a href="#q1">ユーザー登録とログイン（会員管理）</a>
  ★☆☆☆☆</li>
  <li><a href="#q2">落書きを描く機能</a>
  ★★★★☆</li>
  <li>画像の保存と取得（ファイルストア）</li>
  <li>画像関するデーターの保存と取得（データーストア）</li>
  <li>人気ランキング機能（データーストア）</li>
</ul>
<h2>事前準備</h2>
<ul>
  <li><b>開発環境</b>
    <ul>
      <li>windows7以上、或いはOS X</li>
      <li>Unity5.3.5以上</li>
    </ul>
  </li>
  <li><b>クラウド</b>
    <ul>
      <li>ニフティクラウドmobile backendの<a href="http://mb.cloud.nifty.com/signup.htm">アカウント</a>（無料）</li>
      <li>mbのアカウントを使って、「Doodle」と言うアプリの<a href="http://mb.cloud.nifty.com/doc/current/introduction/quickstart_unity.html#アプリの新規作成">新規作成</a>（無料）</li>
    </ul>
  </li>
  <li><b>新しいユニティープロジェクトを作成</b>
    <ul>
      <li>新しい2Dプロジェクトを作成する</li>
      <li>mb SDKを<a href="http://mb.cloud.nifty.com/doc/current/introduction/quickstart_unity.html#SDKのダウンロード">インストール</a></li>
      <li>SDKを<a href="http://mb.cloud.nifty.com/doc/current/introduction/quickstart_unity.html#APIキーの設定とSDKの初期化">初期化</a></a><b>（自分のAPI KeyとClient Keyを「NCMBSetting」に輸入して下さい）</b>
    </ul>
</ul>
<h2 id="q1">『問題一』　ユーザー登録とログイン（会員管理）</h2>
<h5>難易度/★☆☆☆☆</h5>
<ul>
  <li><b>mbの会員管理機能について</b><br/>
  	<p>ニフティクラウドmobile backendが提供する機能の一つ。アプリ利用者に会員登録を意識させない形で会員管理を行えます。
  	詳しくのは<a href="http://mb.cloud.nifty.com/doc/current/user/basic_usage_unity.html">ドキュメント</a>を参考下さい。
  	</p>
  </li>
  <li><b>キーコード</b>
  <p>1. 先ずは、ニックネーム、パスワードを輸入するための「InputField」（UGUI Component）と登録、ログインのボタンを作ります。<br/>
  2.「ButtonContrller」と言うC#スクリプトを生成します。<br/>
  3. 「Scene」で「Controller」と言うGameobjectを生成して、「ButtonController」をGameobjectにつきます。
  </p>
  「ButtonController」の中は、ボタンのクリックイベントを処理するためのコードです。<br/>
  登録ボタンを処理するコードは以下：
  <pre>
	public InputField nameInput;
	public InputField passwordInput;
	public void OnSignUp(){
		//NCMBUserのインスタンス作成 
		NCMBUser user = new NCMBUser();
		//ユーザ名とパスワードの設定
		user.UserName = nameInput.text;
		user.Password = passwordInput.text;
				
		//会員登録を行う
		user.SignUpAsync((NCMBException e) => { 
			if (e != null) {
				UnityEngine.Debug.Log ("新規登録に失敗: " + e.ErrorMessage);
			} else {
				UnityEngine.Debug.Log ("新規登録に成功");
				//新しいシーンをロード
				Application.LoadLevel("title");
			}
		});
	}
  </pre>
  ユニティーに戻って、「登録」ボタンをクリックする。ボタンのOnClickファンクションの所に、「＋」マックをクリックして下さい。
　<p><img src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/redhi.jpg"/></p>
  「Controller」を下にドラッグし、OnSignUp()ファンクションを選択します。
  <p><img src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/onclick.jpg"></p>
   「Controller」をクリックして、ニックネームとパスワードの入力ボックスを「nameInput」と「passwordInput」にドラッグします。
  <p><img src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/conse.jpg"></p>
   以上は、登録効能の基本でした。
  </li>
  <li><b>ディスカッション</b>
  <br/>ログインとログアウトの機能を挑戦しませんか？ ┃難易度★☆☆☆☆
  <br/><b>【アンサー】</b></br>
  <a href="https://github.com/ellentby/Doodle-DrawTogether/blob/tutorial/Assets/script/ButtonController.cs">ログインの答え</a>
  search key: Discussion 1 Log In<br/>
  <a href="https://github.com/ellentby/Doodle-DrawTogether/blob/tutorial/Assets/script/ButtonController.cs">ログアウトの答え</a>
　search key: Discussion 2 Log Out<br/>
  <a href="#discussionanswer">答えを探す方法</a>
  </li>
  <li><b>ヒント</b>
  <br/>- ニックネームとパスワード両方の輸入が必要ため、チェックファンクションが必要。
  <br/>- SignUpAsync()ファンクションは、同調ファンクションではありません。
　<br/>- ボタンにGameobjectをドラッグし、クリックイベントを処理するためのファンクションを選ぶ、と言うことはUnity専有の機能で、使い安いです。
  </li>
</ul>
<span><a href="#keyquestion">問題リストに戻る</a></span>
<h2 id="q2">『問題二』　落書きを描く機能</h2>
<h5>難易度/★★★★☆</h5>
<ul>
  <li>機能の説明<br/>
      この機能では、UnityEngineの「LineRenderer」と言うクラスを使っています。<br/>
     「LineRender」のメソッド「SetPosition()」と「SetPositions()」を利用して、線の頂点を設置することができます。<br/>
      でも、一つのLineRenderは一つの線しか画けません。そして、一つのGameobjectは、一つのLineRendererだけに対応する。
　　　<br/>ですから、毎回新しい線を画きたいとき、スクリプトで新しいGameobjectが生成する。<br/>
      「LineRenderer」の関して、Unityの<a href="http://docs.unity3d.com/jp/current/ScriptReference/LineRenderer.html">ドキュメント</a>をご参考下さい。
  </li>
  <li><b>キーコード</b><br/>
　1. 「DrawLine」と言うスクリプトを生成します。<br/>
　2. 「DrawLine」で、「defaultRenderer」と言うLineRendererを定義し、設定します。
  <pre>
   defaultRenderer = gameObject.GetComponent();
   defaultRenderer.material = new Material (shader);
   defaultRenderer.SetVertexCount (0);
   defaultRenderer.SetWidth (0.1f, 0.1f);
   defaultRenderer.SetColors (Color.green, Color.green);
   defaultRenderer.useWorldSpace = true;
  </pre>
　3. シーンで、「Line0」と言うGameobjectを生成します。「LineRenderer」を「Line0」に付きます。<br/>
　4. シーンで「DrawingPanel」と言うパネルを生成し、スクリプトから獲得します。（この「DrawingPanel」は、スクリーンの上で絵を書くエリアです。）
  <pre>
  panel = GameObject.Find ("DrawingPanel");
　</pre>
　5. 以下のコードをUpdate()に追加します。
  <pre>
	if (Input.GetMouseButtonDown (0)) {
            //to check if this line renderer is used. If it is, create a new line renderer(on a new Gameobject)
            //(so that more than 1 lines can be rendered)
            if(!used){
                used = true;
                isMousePressed = true;
                defaultRenderer.SetVertexCount (0);
                pointList.RemoveRange (0, pointList.Count);
            }else if(!newCreated){
                //to draw more than 1 lines, we have to create a new gameObejct
                GameObject newRenderer = GameObject.Instantiate (rendererPrefab);
                newCreated = true;
                newRenderer.GetComponent ().init();
            }
        }
        if (Input.GetMouseButtonUp (0)) {
            isMousePressed = false;}
        if (isMousePressed && IfInDrawingCanvas()) {
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePos.z = 0;
		if (!pointList.Contains (mousePos)) {
			pointList.Add (mousePos);
			defaultRenderer.SetVertexCount (pointList.Count);
			defaultRenderer.SetPosition (pointList.Count - 1, (Vector3)pointList [pointList.Count - 1]);
		}
	}
  </pre>
  以上のスクリプトで使う変数の定義：
  <pre>
	private bool isMousePressed = false;
	public List<Vector3> pointList;
	private Vector3 mousePos;
	private LineRenderer defaultRenderer;
	private bool used = false;
	private bool newCreated = false;
	//Prefeb of Gameobject "Line0"
	public GameObject rendererPrefab;
	private GameObject panel;
  </pre>
  以上のスクリプトで使う関数：
　<pre>
	bool IfInDrawingCanvas(){
		if (Screen.height - Input.mousePosition.y < (-panel.GetComponent<RectTransform> ().offsetMax.y) ||
		   Screen.height - Input.mousePosition.y > (Screen.height - panel.GetComponent<RectTransform> ().offsetMin.y)) {
			return false;
		}
		if (Input.mousePosition.x < panel.GetComponent<RectTransform>().offsetMin.x || 
			Input.mousePosition.x > (Screen.width + panel.GetComponent<RectTransform>().offsetMax.x)){ 
			return false;
		}
		return true;
	}
	public void init(){
		used = true;
		isMousePressed = true;
		pointList.RemoveRange (0, pointList.Count);
	}
  </pre>
  </li>
  <li><b>ヒント</b><br/>
  複数の線を画く方法を紹介しましだが、もし、一つの線だけ画きたい場合、<a href="http://qiita.com/kwst/items/ad61e72562a8bcd9a9f7">こちら</a>をご参考下さい。
 </li>
  <li><b>ディスカッション</b><br/>
  線の色や、ブラッシュのサイズを変えてみますか？┃難易度★★★☆☆</li>
</ul>
<h2 id="discussionanswer">ディスカッションの答えを探す方法</h2>
<p>1. 提供されたURLをクリックして下さい。<br/>
2. Ctrl+Fを押し下さい（MACの場合、Command＋F）。<br/>
3. 出できた検査ボクスに提供されたsearch keyを輸入して「Enter」を押して下さい。
<img src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/searchbox.JPG"/><br/>
4. コメントとその下のコードはあなたが探したい答えですよ！(つ´ω`)つ<br/>
<a href="#contents">「コンテンツ概要」に戻る</a>
</p>
<h2>お問い合わせ</h2>
<p>このゲームについての質問は、作者のE－メールに投稿ください。
<br/>作者のE－メール：ellentby@163.com</p>
<p>mbに質問、意見など、<a href="http://mb.cloud.nifty.com/faq.htm">こちら</a>に参考して下さい。
<br/>或いは、<a href="https://github.com/NIFTYCloud-mbaas/UserCommunity">こちら</a>に投稿してください。
</p>
