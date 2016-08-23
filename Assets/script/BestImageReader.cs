using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using NCMB;
using System;
using System.Collections.Generic;

public class BestImageReader : MonoBehaviour {
	public List<Image> images;
	public int page = 0;
	int imageCount = 0;
	int nowImageIndex = -1;
	public int maxCountInPage;
	string pictureType;
	public GameObject noText;
	public Sprite transSprite;
	// Use this for initialization
	void Start () {
		loadImages ();
	}

	// Update is called once per frame
	void Update () {

	}

	void loadImages(){
		InitNowImageIndex ();
		InitImages ();

		//QueryTestを検索するクラスを作成
		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("DoodleRecord");
		//Scoreの値が7と一致するオブジェクト検索
		query.WhereEqualTo ("date", DateTime.Now.Date);
		query.WhereEqualTo ("type", "doodle");
		query.OrderByDescending ("likes");
		//取得件数の指定
		query.Limit = maxCountInPage;
		//取得開始位置の指定
		query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {
			if (e != null) {
				//検索失敗時の処理
			} else {
				//Scoreが7のオブジェクトを出力
				foreach (NCMBObject obj in objList) {
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
		Resources.UnloadUnusedAssets(); //一定要清理游离资源。
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
		if (nowImageIndex >= maxCountInPage) {
			nowImageIndex = 0;
		}
		return nowImageIndex;
	}

	int InitNowImageIndex(){
		nowImageIndex = -1;
		return nowImageIndex;
	}

	void InitImages(){
		for (int i = 0; i < maxCountInPage; i++) {
			images [i].sprite = transSprite;
		}
	}

	//next: +1
	//previous: -1
	public int SetPage(int i){
		page = page + i;
		if (page < 0) {
			page = 0;
			return page;
		}
		if (page > maxPage()) {
			page = maxPage();
			return page;
		}
		loadImages ();
		return page;
	}

	int maxPage(){
		double floor = Math.Floor ((double)imageCount / maxCountInPage);
		double ceiling = Math.Ceiling ((double)imageCount / maxCountInPage);
		if (floor == 0) {
			return 0;
		}
		if (floor == ceiling) {
			return (int)floor - 1;
		}
		return (int)floor;
	}
}

