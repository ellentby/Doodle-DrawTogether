# Doodle-DrawTogether

<h3>同じテーマを基にして一緒に自分の落書き作品を作りましょ！</h3>
「Doodle」では、ユーザーがテーマとしての簡単の線を書くことが出来る、そして、テーマを基にして、自分の落書き作品を書くことも出来ます。最も人気高い落書きは、本日ベストになります。
<br/>
<b>このゲームは、ニフティクラウドmobile backendのサンプルです。</b>
<br/><br/>
<img width="400px" src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/100.jpg"/>
<img width="400px" src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/101.jpg"/>
<img width="400px" src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/102.jpg"/>
<img width="400px" src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/103.jpg"/>
<h2 id="contents">ドキュメント概要</h2>
<ul>
  <li><h3><a href="#preparation">事前準備</a></h3>
  この部分で、正式な開発が始まる前に必要された手順を説明します。「Doodle」だけではなく、他のニフティクラウドmobile backend（下記mb）を利用したアプリ作りも、同じ手順が必要です。
  </li>
  <li><h3><a href="#keyquestion">キー問題</a></h3>
  キー問題は、「Doodle」の核としての５つの機能を提出し、解説するパートです。キー問題の解説は、以下の手順で行われます。
  	<ul>
  		<li><b>mbの機能について解説</b><br/>
  		「Doodle」では、mbの「会員管理」、「データストア」、「ファイルストア」の三つの機能を使っています。 問題に対応するmbの機能を紹介します。<br/>
  			<img width="400px"src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/3functions.jpg"/>
  		</li>
  		　<li><b>ゲーム機能の説明</b><br/>
		    問題に対応するゲームの機能を紹介します。
		  </li>
		  <li><b>説明対象</b><br/>
		    以下の「主な流れ」で説明する流れに拘るGameobject（スクリプト、ボタンなど）
		  </li>
		  <li><b>主な流れ</b><br/>
		  機能を作成する手順。キーコードとそれに関するUnityの操作を紹介します。
		  </li>
		  <li><b>ディスカッション</b><br/>
		  問題の解説を見て、御自身も試したいと思ったら、是非ディスカッションの問題をご覧ください！
	  	　<br/>質問の答えは全部プロジェクトのコードにあります。答えを探す方法は<a href="#discussionanswer">こちら</a>。
		  </li>
		  <li><b>ヒント</b><br/>
		  mbに関して注意すべきこと、Unityの便利な機能など、ヒントの部分で紹介されています。
		  </li>
  	</ul>
  </li>
  <li><h3><a href="#discussionanswer">ディスカッションの答えを探す方法</a></h3>
  	キー問題のディスカッションの部分で、質問を提出しましたが、その質問の答えを探す方法。
  </li>
  <li><h3><a href="#communication">お問い合わせ</a></h3>
  ゲーム、或いはmbについての質問のお問い合わせ。
  </li>
</ul>
<h3>開発者として、mbの便利さを利用しながら、ゲームプレーヤーとしての嬉しさも楽しもう！</h3>

<h2 id="preparation">事前準備</h2>
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
  <li><b>新しいUnityプロジェクトを作成</b>
    <ul>
      <li>新しい2Dプロジェクトを作成する</li>
      <li>mb SDKを<a href="http://mb.cloud.nifty.com/doc/current/introduction/quickstart_unity.html#SDKのダウンロード">インストール</a></li>
      <li>SDKを<a href="http://mb.cloud.nifty.com/doc/current/introduction/quickstart_unity.html#APIキーの設定とSDKの初期化">初期化</a></a><b>（自分のAPI KeyとClient Keyを「NCMBSetting」に輸入して下さい）</b>
    </ul>
</ul>

<h2 id="keyquestion">キー問題</h2>
<ul>
  <li><a href="#q1">ユーザー登録とログイン（会員管理）</a>
  ★☆☆☆☆</li>
  <li><a href="#q2">落書きを描く機能</a>
  ★★★★☆</li>
  <li><a href="#q3">画像の保存と取得（ファイルストア）</a>
  ★★☆☆☆</li>
  <li><a href="#q4">画像に関するデータの保存と取得（データストア）</a>
  ★☆☆☆☆</li>
  <li><a href="#q5">人気ランキング機能（データストア）</a>
  ★★★☆☆</li>
</ul>

<h2 id="q1">『問題一』　ユーザー登録とログイン（会員管理）</h2>
<h5>難易度/★☆☆☆☆</h5>
<ul>
  <li><b>mbの会員管理機能について</b><br/>
  	<p>ニフティクラウドmobile backendが提供する機能の一つ。アプリ利用者に会員登録を意識させない形で会員管理を行えます。
  	詳しくのは<a href="http://mb.cloud.nifty.com/doc/current/user/basic_usage_unity.html">ドキュメント</a>を参考下さい。
  	</p>
  </li>
  <li><b>説明対象</b><br/>
  シーン「login」のGameobject「Name」（Inputfield）、「Password」（Inputfield）、「Login」（Button）、「SignUp」（Button）、Gameobject「Controller」Component「ButtonController」（Script）。
  </li>
  <li><b>主な流れ</b>
  <p>1. 先ずは、ニックネーム、パスワードを輸入するための「InputField」（UGUI Component）と登録、ログインのボタンを作ります。<br/>
  2.「ButtonContrller」と言うC#スクリプトを生成します。<br/>
  3. シーンで「Controller」と言うGameobjectを生成して、「ButtonController」をGameobjectにつきます。
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
  4. ユニティーに戻って、「登録」ボタンをクリックする。ボタンのOnClick関数の所に、「＋」マックをクリックして下さい。
　<p><img src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/redhi.jpg"/></p>
  5. 「Controller」を下にドラッグし、OnSignUp()ファンクションを選択します。
  <p><img src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/onclick.jpg"></p>
   6. 「Controller」をクリックして、ニックネームとパスワードの入力ボックスを「nameInput」と「passwordInput」にドラッグします。
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
  <br/>- ニックネームとパスワード両方の輸入が必要ため、チェックする関数が必要。
  <br/>- SignUpAsync()関数は、同期処理の関数ではありません。即ち、SignUpAsync()がコールされた後、その執行を待つではなく、コールの後のコートを執行する。
　<br/>- ボタンにGameobjectをドラッグし、クリックイベントを処理する関数を選ぶ、と言うことはUnity専有の機能で、使い易いです。
  </li>
</ul>
<span><a href="#keyquestion">問題リストに戻る</a></span>
<h2 id="q2">『問題二』　落書きを描く機能</h2>
<h5>難易度/★★★★☆</h5>
<ul>
  <li>描く機能の説明<br/>
      この機能では、UnityEngineの「LineRenderer」と言うクラスを使っています。<br/>
     「LineRender」のメソッド「SetPosition()」と「SetPositions()」を利用して、線の頂点を設置することができます。<br/>
      ですが、一つのLineRenderは一本の線しか描けません。そして、一つのGameobjectは、一つのLineRendererだけに対応する。
　　　<br/>ですから、毎回新しい線を画きたいとき、スクリプトで新しいGameobjectを生成する。<br/>
      「LineRenderer」の関して、Unityの<a href="http://docs.unity3d.com/jp/current/ScriptReference/LineRenderer.html">ドキュメント</a>をご参考下さい。
  </li>
  <li><b>主な流れ</b><br/>
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
　3. シーンで、「Line0」と言うGameobjectを生成します。「Add　Component」の所で、「LineRenderer」を生成します。<br/>
　4. シーンで「DrawingPanel」と言うパネルを生成し、以下のコードに通し、スクリプトから獲得します。（この「DrawingPanel」は、スクリーンの上で絵を書くエリアです。）
  <pre>
  panel = GameObject.Find ("DrawingPanel");
　</pre>
　5. 以下のコードを「DrawLine.cs」のUpdate()函数に追加します。
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
  以上のスクリプトが使う変数の定義：
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
  以上のスクリプトが使う関数：
　<pre>
	//マウスは「DrawingPanel」のエリアにあるがどうか確認する
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
	//「DrawLine」を初期化する
	public void init(){
		used = true;
		isMousePressed = true;
		pointList.RemoveRange (0, pointList.Count);
	}
  </pre>
  </li>
  <li><b>ヒント</b><br/>
  複数の線を画く方法を紹介しましだが、もし、一本の線だけ描きたい場合、<a href="http://qiita.com/kwst/items/ad61e72562a8bcd9a9f7">こちら</a>をご参考下さい。
 </li>
  <li><b>ディスカッション</b><br/>
  ブラッシュの色とサイズを変えてみますか？┃難易度★★★☆☆
  <br/><b>【アンサー】</b>
　</br><a href="https://github.com/ellentby/Doodle-DrawTogether/blob/tutorial/Assets/script/DrawLine.cs">答え</a>　
search key: Discussion 3 Set linerenderer's color and size
  <br/><a href="#discussionanswer">答えを探す方法</a>
</li>
</ul>
<span><a href="#keyquestion">問題リストに戻る</a></span>

<h2 id="q3">『問題三』　画像の保存と取得（ファイルストア）</h2>
<h5>難易度/★★☆☆☆</h5>
<ul>
  <li><b>mbのファイルストア機能について</b><br/>
  	<p>ニフティクラウドmobile backendが提供している、画像やテキスト、音楽などさまざまな種類のファイルを保存することができるストレージ機能です。
  	詳しくのは<a href="http://mb.cloud.nifty.com/doc/current/filestore/basic_usage_unity.html">ドキュメント</a>を参考下さい。
  	</p>
  </li>
  <li><b>主な流れ</b>
  <h5>Step 1 スクリーンショットに通して、画像をゲットする</h5>
  <p>このステップは、「SaveImage」スクリプトの「saveImage()」関数で行う。スクリーンショットをする範囲は、インプットされたGameobjectのエリアだけです。</p>
  <pre>
  	public void saveImage (GameObject go) {
		float width = Screen.width + go.GetComponent<RectTransform>().offsetMax.x - go.GetComponent<RectTransform>().offsetMin.x;
		float height = Screen.height - go.GetComponent<RectTransform> ().offsetMin.y + go.GetComponent<RectTransform> ().offsetMax.y;
	
		renderTexture = new RenderTexture (Screen.width, Screen.height, 0);
		camera.targetTexture = renderTexture;
		camera.Render ();

		RenderTexture.active = renderTexture;
		Texture2D virtualPhoto =
			new Texture2D((int)width, (int)height, TextureFormat.RGB24, false);
		// false, meaning no need for mipmaps
		virtualPhoto.ReadPixels( new Rect(go.GetComponent<RectTransform>().offsetMin.x, 
			go.GetComponent<RectTransform>().offsetMin.y, 
			width, height), 0, 0);

		RenderTexture.active = null; //can help avoid errors 
		camera.targetTexture = null;

		//pngに転換する
		byte[] bytes;
		bytes = virtualPhoto.EncodeToPNG();
		saveToCloud (bytes,getName());
	}
  </pre>
  <h5>Step 2 画像をクラウドに保存する</h5>
  <p>ここで、mbのSDKを使います。簡単なコードで、クラウドに保存できます。以下のコードで使われる関数「saveImageData()」は、次の問題で話します。</p>
  <pre>
  	void saveToCloud(byte[] bytes, string name){
		NCMBFile file = new NCMBFile (name, bytes);
		file.SaveAsync ((NCMBException error) => {
			if (error != null) {
				Debug.Log("upload error");
                showError(error);
				// 失敗
			} else {
				saveImageData(name);
			}
		});
	}
  </pre>
  <h5>Step 3 Unityの設定</h5>
  <p>「SaveImage.cs」を「Drawing」シーンの中の「Controller」に付き、MainCameraを「Camera」の所にドラッグします。</p>
  <img src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/saimg.JPG"/>
  </li>
  <li><b>ディスカッション</b>
  <br/>クラウドから画像を取得することも同じく簡単です！ ┃難易度★☆☆☆☆
  <br/>クラウドから取得した画像のタイプはbyte[]ですが、どうやってUnityに使えますか？ ┃難易度★★☆☆☆
  <br/><b>【アンサー】</b></br>
  <a href="https://github.com/ellentby/Doodle-DrawTogether/blob/tutorial/Assets/script/ThemeImageController.cs">画像取得の答え</a>
  search key: Discussion 4 Load from cloud<br/>
  <a href="https://github.com/ellentby/Doodle-DrawTogether/blob/tutorial/Assets/script/ThemeImageController.cs">byte[]の答え</a>
　search key: Discussion 5 Deal with byte[] data<br/>
  <a href="#discussionanswer">答えを探す方法</a>
  </li>
  <li><b>ヒント</b>
  <br/>- ログインと同じ、ファイルの保存と取得も同調ではないです。
  <br/>- クラウドに保存したファイルは、mbの<a href="https://console.mb.cloud.nifty.com">管理画面</a>で見られます。
  「アプリ設定」⇒「データ-ファイルストア」の「HTTPSでの取得」を「有効」にしたら、ファイルの公開URLが取得できます。とても便利な機能です。
  </li>
</ul>
<span><a href="#keyquestion">問題リストに戻る</a></span>


<h2 id="q4">『問題四』　画像に関するデータの保存と取得（データストア）</h2>
<h5>難易度/★☆☆☆☆</h5>
<ul>
  <li><b>mbのデータストア機能について</b><br/>
  	<p>ニフティクラウドが提供している、アプリで利用されるデータを保存・共有することができるデータベース機能です。
  	詳しくのは<a href="http://mb.cloud.nifty.com/doc/current/datastore/basic_usage_unity.html">ドキュメント</a>を参考下さい。
  	</p>
  </li>
  <li><b>主な流れ</b>
  <p>
  	画像をクラウドに保存するだけではなく、画像に関するデーター（画像の名前、描いた人のニックネームなど）も保存する必要もあります。それが、画像を検索する時の証拠になるますから。
  </p>
  <h5> データを保存する場合
  <p>
  	mbのSDKに通して、簡単にデータを保存できます。
  </p>
  	<pre>
  	void saveImageData(string filename){
		NCMBObject obj = new NCMBObject ("DoodleRecord");
		obj.Add ("username", Configuration.username);
		obj.Add ("filename", filename);
		obj.Add ("date", DateTime.Now.Date);
		obj.Add ("theme", Configuration.theme);
		obj.Add ("likes", 0);
		
		obj.Save ((NCMBException e) => {      
			if (e != null) {
				Debug.Log("save data error");
			} else {
				//成功時の処理
				if(Configuration.status == Status.newTheme){
					Application.LoadLevel("themes");
				}else if(Configuration.status == Status.newDoodle){
					Application.LoadLevel("doodles");
				}
			}                   
		});
	}
  	</pre>
  <h5>データを取得する場合</h5>
  <p>
  	データーを取得する時、先ずは検索の条件を決まります。sqlと同じ、mbのSDKは、「NCMBQuery.WhereEqualTo(KEY,VALUE)」、「limit」、「skip」などの関数に通して、検索条件を指定できます。詳しくは<a href="http://mb.cloud.nifty.com/doc/current/datastore/basic_usage_unity.html#基本的な検索の利用">ドキュメント</a>をご参考ください。
  </p>
  <pre>
  	void loadImages(){
		//QueryTestを検索するクラスを作成
		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("DoodleRecord");

		query.WhereEqualTo ("date", DateTime.Now.Date);
		query.WhereEqualTo ("type", pictureType);
		if (pictureType == "doodle") {
			query.WhereEqualTo ("theme", Configuration.theme);
		}
		query.OrderByDescending ("createDate");
		//取得件数の指定
		query.Limit = maxCountInPage;
		//取得開始位置の指定
		query.Skip = page * maxCountInPage;
		query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {
			if (e != null) {
				//検索失敗時の処理
			} else {
				//Scoreが7のオブジェクトを出力
				foreach (NCMBObject obj in objList) {
					//ファイルネームに通し、画像をクラウドからダウンロードする
					NextImageIndex();
					imageData.Add(obj);
					InitLike(nowImageIndex);
					loadOneImageTo(obj["filename"].ToString(), nowImageIndex);
				}
			}
		});
	}
  </pre>
  </li>
  <li><b>ヒント</b>
  <br/>- データを保存する場合、NCMBObject.save()とNCMBObject.saveAsync()の二つの関数を使えられます。save()は同時処理で、saveAsync()は非同時処理ですが、どちらを使うのは状況次第です。
  </li>
</ul>
<span><a href="#keyquestion">問題リストに戻る</a></span>


<h2 id="q5">『問題五』　人気ランキング機能（データストア）</h2>
<h5>難易度/★★★☆☆</h5>
<ul>
  <li><b>mbのデータストア機能について</b><br/>
  	<p><a href="#q4">問題四</a>の「mbのデータストア機能について」部分をご覧ください。
  	</p>
  </li>
  <li><b>ランキング機能の説明</b><br/>
  	<p>
  	「Doodle」のランキング機能は、Twitterの「いいね」と似て、作品を好きな人の数で決まります。落書き作品の右上のハートマークをクリックすると、ハート全体が赤くなって、「この作品に1票を投じました」を表示します。<br/>
  	<img height="200px" src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/likee.png"/>
  	<br/>もし、赤くなったハートをもう一度クリックすると、以上のアクションは消します。
  	<br/>
  	一番人気な落書きは、ゲームの主要画面の左に表示されます。クリックすると、人気一位から四位までの落書き作品が見られます。
  	<br/>
  	<img height="200px" src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/best0.png"/><br/>
  	</p>
   </li>
  <li><b>主な流れ</b>
  	<h5>Step 1 ハートマークのSpriteの定義と取得</h5>
  	Gameobjectの「Controller」に付ける「ThemeImageController」のスクリプトの中で、以下の変数を定義する。
	<pre>
	//空きハートのSprite
	public Sprite likeSprite;
	//全体赤いハートのSprite
	public Sprite likeClickedSprite;
	</pre>
  	<p>
  	この二つのハートマークを定義し、UnityからSpriteファイルを取得する。<br/>
  	<img src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/likeU.JPG"/>
  	</p>
  	<h5>Step 2 ハートマークの切り替え、データの保存</h5>
  	<p>ハートマークをクリックする時、更新すべきデータが二箇所あります。<br/>
  	1. 「データストア」⇒　クラス「DoodleRecord」 ⇒　「likes」<br/>
  	   &nbsp;&nbsp;&nbsp;&nbsp;ここでは、落書きのデータが保存しています。
  	<img src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/like-.JPG"/>
  	2.  「データストア」⇒ 　クラス「LikeRecord」⇒　新規記録<br/>
  	&nbsp;&nbsp;&nbsp;&nbsp;ここでは、投票記録が保存しています。<br/>
	<img src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/lirc.JPG"/>
  	<br><br/>
	ハートマークをクリックするアクションは、LightUpLike(INDEX)関数で処理します。インプットされた「index」は、
	シーンの中のハートマークの番号です。
	<br/><br/>関数LightUpLike():
	</p>
  	<pre>
  	public void LightUpLike(int index){
  		//まだクリックしてない場合
		if (this.likes [index].sprite == likeSprite) {
			//ハートマークを切り替え
			this.likes [index].sprite = likeClickedSprite;
			//好きな人数を取得
			int likeCount = int.Parse(imageData[index]["likes"].ToString());
			//人数を更新し
  			likeCount++;
  			imageData[index]["likes"] = likeCount;
			//「誰がどれを好き」の記録を保存する
			SaveLikeData (NCMBUser.CurrentUser.ObjectId,  imageData[index]["filename"].ToString());
		//クリックした場合	
		} else if (this.likes [index].sprite == likeClickedSprite) {
			this.likes[index].sprite = likeSprite;
			int likeCount = int.Parse(imageData[index]["likes"].ToString());
			likeCount--;
			imageData[index]["likes"] = likeCount;
			//「誰がどれを好き」の記録を消す
			DeleteLikeData (NCMBUser.CurrentUser.ObjectId, imageData[index]["filename"].ToString());
		}
		//好きな人数を更新する
		imageData[index].SaveAsync ((NCMBException e2) => {      
			if (e2 != null) {
			//エラー処理
			} else {
			//成功時の処理
			}                   
		});
	}
	</pre>
	<p>「LikeRecord」の新規生成：</p>
	<pre>
	void SaveLikeData(string user, string doodle){
		NCMBObject obj = new NCMBObject ("LikeRecord");
		obj.Add ("doodle", doodle);
		obj.Add ("user", user);
		obj.Save ((NCMBException e) => {      
			if (e != null) {
				Debug.Log("save like data error");
			} else {
				//成功時の処理
			}                   
		});
	}
	</pre>
	<p>存在している「LikeRecord」を消す：</p>
	<pre>
	void DeleteLikeData(string user, string doodle){
		//LikeRecordを検索するクラスを作成
		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("LikeRecord");
		query.WhereEqualTo ("user", user);
		query.WhereEqualTo ("doodle", doodle);
		query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {
			if (e != null) {
				//検索失敗時の処理
			} else {
				foreach (NCMBObject obj in objList) {
					Debug.Log ("delete objectId:" + obj.ObjectId);
					obj.DeleteAsync ((NCMBException deleteError) => {
						if (deleteError != null) {
							//エラー処理
						} else {
							//成功時の処理
						}
					});
				}
			}
		});
	}
  	</pre>
  </li>
  <li><b>ディスカッション</b>
  <br/>「DoodleRecord」の「likes」を利用したら、ランキングを作られるですが、それを試してみますか？難易度★★☆☆☆
  <br/><b>【アンサー】</b></br>
  <a href="https://github.com/ellentby/Doodle-DrawTogether/blob/tutorial/Assets/script/BestImageReader.cs">答え</a>
  search key: Discussion 6 Like Ranking<br/>
  <a href="#discussionanswer">答えを探す方法</a>
  </li>
</ul>
<span><a href="#keyquestion">問題リストに戻る</a></span>


<h2 id="discussionanswer">ディスカッションの答えを探す方法</h2>
<p>1. 提供されたURLをクリックして下さい。<br/>
2. Ctrl+Fを押し下さい（MACの場合、Command＋F）。<br/>
3. 出できた検査ボクスに提供されたsearch keyを輸入して「Enter」を押して下さい。
<img src="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/searchbox.JPG"/><br/>
4. 検索結果とその下のコードはあなたが探したい答えですよ！(つ´ω`)つ<br/>
<a href="#contents">「ドキュメント概要」に戻る</a>
</p>
<h2 id="communication">お問い合わせ</h2>
<p>このゲームについての質問は、作者のメールアドレスに投稿ください。
<br/>作者のメールアドレス：ellentby@163.com</p>
<p>mbに質問、意見など、<a href="http://mb.cloud.nifty.com/faq.htm">こちら</a>に参考して下さい。
<br/>或いは、<a href="https://github.com/NIFTYCloud-mbaas/UserCommunity">こちら</a>に投稿してください。
</p>
<a href="#contents">「ドキュメント概要」に戻る</a>
