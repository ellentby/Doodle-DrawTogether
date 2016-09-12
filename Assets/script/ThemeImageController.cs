using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using NCMB;
using System;
using System.Collections.Generic;

public class ThemeImageController : MonoBehaviour {
	public List<Image> images;
	public List<Image> likes;
	public Sprite likeSprite;
	public Sprite likeClickedSprite;
	List<NCMBObject> imageData;
	public int page = 0;
	int imageCount = 0;
	int nowImageIndex = -1;
	int maxCountInPage = 4;
	string pictureType;
	public Sprite transSprite;
	public GameObject noText;
	// Use this for initialization
	void Start () {
		getPictureType ();
		GetImageCount ();
		loadImages ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void getPictureType(){
		if (Configuration.status == Status.newDoodle) {
			pictureType = "doodle";
		}
		if (Configuration.status == Status.newTheme 
			|| Configuration.status == Status.theme) {
			pictureType = "theme";
		}
	}

	void GetImageCount(){
		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("DoodleRecord");
		query.WhereEqualTo ("date", DateTime.Now.Date);
		query.WhereEqualTo ("type", pictureType);
		if (pictureType == "doodle") {
			query.WhereEqualTo ("theme", Configuration.theme);
		}
		query.CountAsync((int count , NCMBException e )=>{
			if(e != null){
				//件数取得失敗時の処理
			}else{
				//件数を出力
				imageCount = count;
				if(imageCount == 0){
					noText.SetActive(true);
				}
			}
		});
	}

	void loadImages(){
		InitNowImageIndex ();
		InitImages ();
		imageData = new List<NCMBObject> ();

		//QueryTestを検索するクラスを作成
		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("DoodleRecord");
		//Scoreの値が7と一致するオブジェクト検索
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
					NextImageIndex();
					imageData.Add(obj);
					InitLike(nowImageIndex);
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
			if(likes.Count > i){
				likes [i].sprite = transSprite;
			}
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

	public NCMBObject GetImageData(int i){
		return imageData [i];
	}

	public void LightUpLike(int index){
		if (this.likes [index].sprite == likeSprite) {
			this.likes [index].sprite = likeClickedSprite;
			int likeCount = int.Parse(imageData[index]["likes"].ToString());
  			likeCount++;
  			imageData[index]["likes"] = likeCount;
			//SAVE THE LIKE RECORD - WHO LIKE WHICH DOODLE
			SaveLikeData (NCMBUser.CurrentUser.ObjectId,  imageData[index]["filename"].ToString());
		} else if (this.likes [index].sprite == likeClickedSprite) {
			this.likes[index].sprite = likeSprite;
			int likeCount = int.Parse(imageData[index]["likes"].ToString());
			likeCount--;
			imageData[index]["likes"] = likeCount;
			DeleteLikeData (NCMBUser.CurrentUser.ObjectId, imageData[index]["filename"].ToString());
		}
		//TODO 
		//UPDATE THE NUMBER OF LIKES
		imageData[index].SaveAsync ((NCMBException e2) => {      
			if (e2 != null) {
			//エラー処理
			} else {
			//成功時の処理
			}                   
		});
	}
	void InitLike(int index){
		if(likes.Count == images.Count){
			this.likes [index].sprite = likeSprite;

			//QueryTestを検索するクラスを作成
			NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("LikeRecord");
			//Scoreの値が7と一致するオブジェクト検索
			query.WhereEqualTo ("user", NCMBUser.CurrentUser.ObjectId);
			query.WhereEqualTo ("doodle", imageData[index]["filename"].ToString());
			query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {
				if (e != null) {
					//検索失敗時の処理
				} else {
					//Scoreが7のオブジェクトを出力
					foreach (NCMBObject obj in objList) {
						this.likes[index].sprite = likeClickedSprite;
					}
				}
			});
		}
	}

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

	void DeleteLikeData(string user, string doodle){
		//QueryTestを検索するクラスを作成
		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("LikeRecord");
		//Scoreの値が7と一致するオブジェクト検索
		query.WhereEqualTo ("user", user);
		query.WhereEqualTo ("doodle", doodle);
		query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {
			if (e != null) {
				//検索失敗時の処理
			} else {
				//Scoreが7のオブジェクトを出力
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
}

