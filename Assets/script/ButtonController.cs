using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using NCMB;

public class ButtonController : MonoBehaviour {
	public Color lineColor;
	public float penWidtn = 0.05f;
	public InputField nameInput;
	public InputField passwordInput;
	public GameObject waitText;
	public int lineIndex;
	public GameObject rendererPrefab;
    public Slider penSizeSlider;
    public Sprite fishOpen;
    public Sprite fishClose;

	// Use this for initialization
	void Start () {
		lineColor = Color.white;
        if (penSizeSlider)
        {
            penSizeSlider.value = 0.2f;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnColorChange(string color){
		Color temp = new Color ();
		switch (color) {
		case "red":
			lineColor = Color.red;
			break;
		case "blue":
			lineColor = Color.blue;
			break;
		case "green":
			lineColor = Color.green;
			break;
		case "skyblue":
			temp = Color.grey;
			temp.r = 0;
			temp.g = 1f;
			temp.b = 1f;
			lineColor = temp;
			break;
		case "yellow":
			temp = Color.grey;
			temp.r = 1f;
			temp.g = 1f;
			temp.b = 0f;
			lineColor = temp;
			break;
		case "pink":
			temp = Color.grey;
			temp.r = 1f;
			temp.g = 0f;
			temp.b = 1f;
			lineColor = temp;
			break;
		case "purple":
			temp = Color.grey;
			temp.r = 0.5f;
			temp.g = 0.5f;
			temp.b = 1f;
			lineColor = temp;
			break;
		case "orange":
			temp = Color.grey;
			temp.r = 0.9f;
			temp.g = 0.6f;
			temp.b = 0f;
			lineColor = temp;
			break;
		case "white":
			lineColor = Color.white;
			break;
		}
	}

	public void OnSubmitImage(GameObject go){
		gameObject.GetComponent<SaveImage> ().saveImage (go);
		waitText.SetActive (true);
	}

	public void OnSlider(Slider slider){
		ChangePenWidthBySlider (slider.value);
	}

	void ChangePenWidthBySlider(float value){
		penWidtn = 0.05f + value * 0.2f;
        if (penSizeSlider.value * 100 % 10 >= 0 && penSizeSlider.value * 100 % 10 <= 5)
        {
            GameObject.Find("FishHandle").GetComponent<Image>().sprite = fishOpen;
        }
        else
        {
            GameObject.Find("FishHandle").GetComponent<Image>().sprite = fishClose;
        }
    }

	public void OnNewTheme(){
		Configuration.status = Status.newTheme;
		Application.LoadLevel ("draw");
		Destroy (this);
	}

	public void OnViewThemes(){
		Configuration.status = Status.theme;
		Application.LoadLevel ("themes");
		Destroy (this);
	}

	public void OnBackToTitle(){
		Configuration.status = Status.idle;
		Application.LoadLevel ("title");
	}

    public void OnQuitGame(){
        NCMBUser.LogOutAsync((NCMBException e) => {
            if (e != null)
            {
                Application.Quit();
            }
            else
            {
                Application.Quit();
            }
        });
	}

	public void OnTurnThemePage(int i){
		GetComponent<ThemeImageController> ().SetPage (i);
	}

	public void OnLogin(){
        GameObject.Find("Notation").GetComponent<Text>().text = "";
        if (IfNamePasswordIsFilledIn ()) {
			// ユーザー名とパスワードでログイン
			NCMBUser.LogInAsync (nameInput.text, passwordInput.text, (NCMBException e) => {    
				if (e != null) {
					UnityEngine.Debug.Log ("ログインに失敗: " + e.ErrorMessage);
					GameObject.Find ("Notation").GetComponent<Text>().text = "ログインに失敗: " + e.ErrorMessage;
				} else {
					
					UnityEngine.Debug.Log ("ログインに成功！");
					GameObject.Find ("Notation").GetComponent<Text>().text = "ログインに成功！";
					Configuration.username = nameInput.text;
					Application.LoadLevel("title");
				}
			});
		}
	}
	public void OnSignUp(){
        GameObject.Find("Notation").GetComponent<Text>().text = "";
        if (IfNamePasswordIsFilledIn ()) {
			//NCMBUserのインスタンス作成 
			NCMBUser user = new NCMBUser();
			//ユーザ名とパスワードの設定
			user.UserName = nameInput.text;
			user.Password = passwordInput.text;

			//会員登録を行う
			user.SignUpAsync((NCMBException e) => { 
				if (e != null) {
					UnityEngine.Debug.Log ("新規登録に失敗: " + e.ErrorMessage);
					GameObject.Find ("Notation").GetComponent<Text>().text = "新規登録に失敗: "
						+ e.ErrorMessage;
				} else {
					UnityEngine.Debug.Log ("新規登録に成功");
					GameObject.Find ("Notation").GetComponent<Text>().text = "新規登録に成功";
					Configuration.username = nameInput.text;
					Application.LoadLevel("title");
				}
			});

		}
	}

	bool IfNamePasswordIsFilledIn(){
		string name = nameInput.text;
		string password = passwordInput.text;
		Text notation =GameObject.Find ("Notation").GetComponent<Text>();
		if (name == "" || password == "") {
			notation.text = "名前とパスワードを輸入してください。";
			return false;
		}
		return true;
	}

	public void OnIDraw(){
		Configuration.status = Status.newDoodle;
		Application.LoadLevel ("draw");
	}

	public void OnTheme(int i){
		Configuration.status = Status.newDoodle;
		NCMBObject obj = GetComponent<ThemeImageController> ().GetImageData (i);
		if (obj == null) {
			return;
		}
		Configuration.themeData = obj;
		Configuration.theme = obj["filename"].ToString();
		Application.LoadLevel ("doodles");
	}

	public void OnLike(int i){
		GetComponent<ThemeImageController>().LightUpLike(i);
	}

	public void OnBest(){
		Application.LoadLevel ("bestDoodle");
	}

	public void Erase(){
		Destroy(GameObject.Find ("Line"+lineIndex));
		if (lineIndex >= 1) {
			lineIndex--;
			GameObject.Find ("Line"+lineIndex).GetComponent<DrawLine>().ReviveRenderer();
		} else{
			GameObject newRenderer = GameObject.Instantiate (rendererPrefab);
			newRenderer.GetComponent<DrawLine> ().initByScript(0);
		}
	}
}

