using UnityEngine;
using System.Collections;
using NCMB;
using UnityEngine.UI;

public class LoadThemeImage : MonoBehaviour {
	public Image image;
	// Use this for initialization
	void Start () {
		if (Configuration.status == Status.newDoodle) {
			loadOneImage (Configuration.theme);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void SaveBytes(byte[] b){
		Texture2D texture = new Texture2D (100,100);
		texture.LoadImage (b);
		Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
		image.sprite = sprite;
		Resources.UnloadUnusedAssets(); //一定要清理游离资源。
	}

	void loadOneImage(string name){
		NCMBFile file = new NCMBFile (name);
		file.FetchAsync ((byte[] fileData, NCMBException error) => {
			if (error != null) {
				// 失敗
			} else {
				SaveBytes(fileData);
			}
		});
	}
}
