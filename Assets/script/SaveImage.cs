using UnityEngine;
using System.Collections;
using System.IO;
using System;
using NCMB;

public class SaveImage : MonoBehaviour {
	public Camera camera;
	RenderTexture renderTexture;

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
		// consider ... Destroy(tempRT);

		byte[] bytes;
		bytes = virtualPhoto.EncodeToPNG();
		saveToCloud (bytes,getName());
		//File.WriteAllBytes(Application.dataPath + "/img/SavedScreen.png", bytes);
	}
	void saveToCloud(byte[] bytes, string name){
		NCMBFile file = new NCMBFile (name, bytes);
		file.SaveAsync ((NCMBException error) => {
			if (error != null) {
				Debug.Log("upload error");
				// 失敗
			} else {
				saveImageData(name);
			}
		});
	}

	string getName(){
		string name = "";
		if (Configuration.status == Status.newTheme) {
			name = "theme";
		}else if(Configuration.status == Status.newDoodle) {
			name = "doodle";
		}
		name = name + "-" + DateTime.Now.Year+DateTime.Now.Month+DateTime.Now.Day+DateTime.Now.Hour+DateTime.Now.Minute+DateTime.Now.Second;
		name = name + "-" + UnityEngine.Random.Range (100000,999999);
		name = name + ".png";
		return name;
	}

	void saveImageData(string filename){
		NCMBObject obj = new NCMBObject ("DoodleRecord");
		obj.Add ("username", Configuration.username);
		obj.Add ("filename", filename);
		obj.Add ("date", DateTime.Now.Date);
		obj.Add ("theme", Configuration.theme);
		obj.Add ("likes", 0);
		if (Configuration.status == Status.newDoodle) {
			obj.Add ("type", "doodle");
		}else if (Configuration.status == Status.newTheme) {
			obj.Add ("type", "theme");
		}
		obj.Save ((NCMBException e) => {      
			if (e != null) {
				Debug.Log("save data error");
			} else {
				//成功時の処理
				//TODO
				if(Configuration.status == Status.newTheme){
					Application.LoadLevel("themes");
				}else if(Configuration.status == Status.newDoodle){
					Application.LoadLevel("doodles");
				}
			}                   
		});
	}
}
