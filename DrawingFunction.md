<h2 id="q2">『機能二』　落書きを描く機能</h2>
<h5>難易度/★★★★☆</h5>
<ul>
  <li>描く機能の説明<br/>
      この機能では、UnityEngineの「LineRenderer」と言うクラスを使っています。<br/>
     「LineRender」のメソッド「SetPosition()」と「SetPositions()」を利用して、線の頂点を設置することができます。<br/>
      ですが、一つのLineRenderは一本の線しか描けません。そして、一つのGameobjectは、一つのLineRendererだけに対応する。
　　　<br/>ですから、毎回新しい線を画きたいとき、スクリプトで新しいGameobjectを生成する。<br/>
      「LineRenderer」の関して、Unityの<a href="http://docs.unity3d.com/jp/current/ScriptReference/LineRenderer.html">ドキュメント</a>をご参考下さい。
  </li>
　<li><b>説明対象</b><br/>
	【シーン「draw」】 <br/>
	「Line0」Component<b>「LineRenderer」</b>、<b>「DrawLine」</b>(Script)
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
　3. シーンで、「Line0」と言うGameobjectを生成します。「Add　Component」の所で、「LineRenderer」を生成します。「DrawLine」を「Line0」に付きます。（<a href="https://mb.api.cloud.nifty.com/2013-09-01/applications/JH0HWGCunFwimk6Q/publicFiles/06LineRenderer2.gif">展示GIFを見る</a>）<br/>
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
<span><a href="#keyquestion">リストに戻る</a></span>
