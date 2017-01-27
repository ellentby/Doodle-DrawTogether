using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour {
	private bool isMousePressed = false;
	public List<Vector3> pointList;
	private Vector3 mousePos;
	private LineRenderer defaultRenderer;
	private bool used = false;
	private bool newCreated = false;
	public GameObject rendererPrefab;
	private int id = 1;
	private GameObject panel;
	public Shader shader;

	void Awake(){
		panel = GameObject.Find ("DrawingPanel");

	}

	// Use this for initialization
	void Start () {
		initDefaultRenderer ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && IfInDrawingCanvas()) {
			//to check if this line renderer is used. If it is, create a new line renderer(on a new Gameobject)
			//(so that more than 1 lines can be rendered)
			if(!used){
                setLineColor();
                setLineWidth();
				used = true;
				isMousePressed = true;
				defaultRenderer.SetVertexCount (0);
				pointList.RemoveRange (0, pointList.Count);
			}else if(!newCreated){
				//to draw more than 1 lines, we have to create a new gameObejct
				GameObject newRenderer = GameObject.Instantiate (rendererPrefab);
				newCreated = true;
				//TODO
				newRenderer.GetComponent<DrawLine> ().init(GameObject.Find("Controller").GetComponent<ButtonController>().lineIndex+1);
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			isMousePressed = false;
		}
		if (isMousePressed && IfInDrawingCanvas()) {
			mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePos.z = 0;
			if (!pointList.Contains (mousePos)) {
				pointList.Add (mousePos);
				defaultRenderer.SetVertexCount (pointList.Count);
				defaultRenderer.SetPosition (pointList.Count - 1, (Vector3)pointList [pointList.Count - 1]);
			}
		}
	}
	//To draw just in the area of panel
	//(mousePosition)y of the bottom is 0, top is the max
	//offsetMin.y is the y of the bottom, which is the max
	//offsetMax.y is the y of the top, which is under 0
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
	//init by click
	public void init(int id){
		this.id = id;
		gameObject.name = "Line" + id;
		gameObject.transform.parent = GameObject.Find ("Lines").gameObject.transform;
		used = true;
		isMousePressed = true;
		pointList.RemoveRange (0, pointList.Count);
		GameObject.Find ("Controller").GetComponent<ButtonController>().lineIndex = id;
		initDefaultRenderer ();
	}

	public void initByScript(int id){
		init (id);
		used = false;
		isMousePressed = false;
	}

	private void setLineColor(){
		Color color = GameObject.Find ("Controller").GetComponent<ButtonController> ().lineColor;
		defaultRenderer.SetColors (color, color);
	}
	private void setLineWidth(){
		float width = GameObject.Find ("Controller").GetComponent<ButtonController> ().penWidtn;
		defaultRenderer.SetWidth (width, width);
	}

	private void initDefaultRenderer(){
		if (defaultRenderer == null) {
			defaultRenderer = gameObject.GetComponent<LineRenderer> ();
			defaultRenderer.material = new Material (shader);
			defaultRenderer.SetVertexCount (0);
		}
		//defaultRenderer.SetWidth (0.1f, 0.1f);
		setLineColor();
		setLineWidth ();
		defaultRenderer.useWorldSpace = true;
	}
	public void ReviveRenderer(){
		newCreated = false;
	}
}

