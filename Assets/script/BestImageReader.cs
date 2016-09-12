using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using NCMB;
using System;
using System.Collections.Generic;

public class BestImageReader : MonoBehaviour {
	public List<Image> images;
	int imageCount = 0;
	int nowImageIndex = -1;
	public int maxCount;
	public Sprite transSprite;
	// Use this for initialization
	void Start () {
        if(Application.loadedLevelName == "title")
        {
            maxCount = 1;
        }else if(Application.loadedLevelName == "bestDoodle")
        {
            maxCount = 4;
        }
		loadImages ();
	}

	// Update is called once per frame
	void Update () {

	}

	void loadImages(){
        
		InitNowImageIndex ();
		InitImages ();

        //DoodleRecordを検索するクラスを作成
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("DoodleRecord");

		query.WhereEqualTo ("date", DateTime.Now.Date);
		query.WhereEqualTo ("type", "doodle");
		query.OrderByDescending ("likes");
		//取得件数の指定
		query.Limit = maxCount;
		//取得開始位置の指定
		query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {
			if (e != null) {
				//検索失敗時の処理
			} else {
				foreach (NCMBObject obj in objList) {
                    Debug.Log("--------------------------------------------------------------");
					NextImageIndex();
					loadOneImageTo(obj["filename"].ToString(), nowImageIndex);
				}
			}
		});
	}

	void SaveBytesTo(byte[] b, int index){
		Texture2D texture = new Texture2D (100,100);
		texture.LoadImage (b);
		Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
		images[index].sprite = sprite;
        Debug.Log("image "+index);
		Resources.UnloadUnusedAssets();
	}

	void loadOneImageTo(string name, int index){
		NCMBFile file = new NCMBFile (name);
		file.FetchAsync ((byte[] fileData, NCMBException error) => {
			if (error != null) {
				// 失敗
			} else {
				SaveBytesTo(fileData,index);
			}
		});
	}

	int NextImageIndex(){
		nowImageIndex++;
		if (nowImageIndex >= maxCount) {
			nowImageIndex = 0;
		}
		return nowImageIndex;
	}

	int InitNowImageIndex(){
		nowImageIndex = -1;
		return nowImageIndex;
	}

	void InitImages(){
		for (int i = 0; i < maxCount; i++) {
			images [i].sprite = transSprite;
		}
	}
}

