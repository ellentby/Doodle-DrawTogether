# 【Unity】アプリにログイン機能をつけよう！
![画像1](https://github.com/hounenhounen/UnityLoginApp/blob/master/readme-img/UnityLogin.png)

## 概要
* [ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)の『会員管理機能』を利用してUnityアプリにログイン機能を実装したサンプルプロジェクトです
* 簡単な操作ですぐに [ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)の機能を体験いただけます★☆

## ニフティクラウドmobile backendって何？？
スマートフォンアプリのバックエンド機能（プッシュ通知・データストア・会員管理・ファイルストア・SNS連携・位置情報検索・スクリプト）が**開発不要**、しかも基本**無料**(注1)で使えるクラウドサービス！今回はデータストアを体験します

注1：詳しくは[こちら](http://mb.cloud.nifty.com/price.htm)をご覧ください

![画像2](https://github.com/natsumo/SwiftLoginApp/blob/master/readme-img/002.png)

## 動作環境
* Mac OS X 10.11.5(EI Capitan)
* Unity ver. 5.2.1f1
* MonoDevelop-Unity ver. 4.0.1

※上記内容で動作確認をしています。


## 手順
### 1. [ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)の会員登録とログイン→アプリ作成

* 上記リンクから会員登録（無料）をします。登録ができたらログインをすると下図のように「アプリの新規作成」画面が出るのでアプリを作成します

![画像3](https://github.com/natsumo/SwiftLoginApp/blob/master/readme-img/003.png)

* アプリ作成されると下図のような画面になります
* この２種類のAPIキー（アプリケーションキーとクライアントキー）はXcodeで作成するiOSアプリに[ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)を紐付けるために使用します

![画像4](https://github.com/natsumo/SwiftLoginApp/blob/master/readme-img/004.png)

* 動作確認後に会員情報が保存される場所も確認しておきましょう

![画像5](https://github.com/natsumo/SwiftLoginApp/blob/master/readme-img/005.png)

### 2. [GitHub](https://github.com/hounenhounen/UnityLoginApp)からサンプルプロジェクトのダウンロード

* この画面([GitHub](https://github.com/hounenhounen/UnityLoginApp))の![画像10](https://github.com/natsumo/SwiftLoginApp/blob/master/readme-img/010.png)ボタンをクリックし、さらに![画像11](https://github.com/natsumo/SwiftLoginApp/blob/master/readme-img/011.PNG)ボタンをクリックしてサンプルプロジェクトをMacにダウンロードします

### 3. Unityでアプリを起動

* ダウンロードしたフォルダを解凍し、Unityから開いてください。その後、Loginsigninシーンを開いてください。


### 4. APIキーの設定

* Loginsigninシーンの`NCMBSettings`を編集します
* 先程[ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)のダッシュボード上で確認したAPIキーを貼り付けます

![画像07](https://github.com/hounenhounen/UnityLoginApp/blob/master/readme-img/ApiKey.png)

* それぞれ`YOUR_NCMB_APPLICATION_KEY`と`YOUR_NCMB_CLIENT_KEY`の部分を書き換えます
 * このとき、ダブルクォーテーション（`"`）を消さないように注意してください！
* 書き換え終わったら`command + s`キーで保存をします

### 5. 動作確認
* Unity画面で上部真ん中の実行ボタン（さんかくの再生マーク）をクリックします

![画像12](https://github.com/hounenhounen/UnityLoginApp/blob/master/readme-img/UnityLogin.png)

* シミュレーターが起動したら、Login&SignIn画面が表示されます
* 初回は__`SignUp`__ ボタンをクリックして、会員登録を行います。

![画像14](https://github.com/hounenhounen/UnityLoginApp/blob/master/readme-img/LoginSignView.png)

* 2回目以降は`UserName`と`Password`を２つ入力してLoginボタンをタップします
* 会員登録が成功するとログインされ、下記画面が表示されます
 * このときmBaaS上に会員情報が作成されます！
 * ログインに失敗した場合は画面にエラー内容が表示されます
 * 万が一エラーが発生した場合は、[こちら](http://mb.cloud.nifty.com/doc/current/rest/common/error.html)よりエラー内容を確認いただけます

![画像15](https://github.com/hounenhounen/UnityLoginApp/blob/master/readme-img/LogOutView.png)

* __`Logout`__ ボタンをタップするとログアウトし、元の画面に戻ります
* 登録された会員情報を使ってLogin画面からログインが可能です（操作は同様です）

-----

* 保存に成功したら、[ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)のダッシュボードから「会員管理」を確認してみましょう！

![画像1](https://github.com/hounenhounen/UnityLoginApp/blob/master/readme-img/UnityLogin.png)

## 解説
サンプルプロジェクトに実装済みの内容のご紹介

#### SDKのインポートと初期設定
* ニフティクラウドmobile backend の[ドキュメント（クイックスタート）](http://mb.cloud.nifty.com/doc/current/introduction/quickstart_unity.html)をUnity版に書き換えたドキュメントをご用意していますので、ご活用ください
 
#### ロジック
 * `Loginsignin.cs`,`Logout.cs`にロジックを書いています
 * ログイン、会員登録、ログアウト部分の処理は以下のように記述されます　※ただし、左記処理以外のコードは除いています

`Loginsignin.cs`

```csharp
// ログイン
public void Login ()
    {
        print (UserName.text);
        print (PassWord.text);

        //NCMBUserのインスタンス作成 
        NCMBUser user = new NCMBUser ();

        // ユーザー名とパスワードでログイン
        NCMBUser.LogInAsync (UserName.text, PassWord.text, (NCMBException e) => {    
            if (e != null) {
                UnityEngine.Debug.Log ("ログインに失敗: " + e.ErrorMessage);
            } else {
                UnityEngine.Debug.Log ("ログインに成功！");
                Application.LoadLevel ("LogOut");
            }
        });

    }
```


```csharp
//会員登録
    public void Signin ()
    {
        print (UserName.text);
        print (PassWord.text);


        //NCMBUserのインスタンス作成 
        NCMBUser user = new NCMBUser ();
        
        //ユーザ名とパスワードの設定
        user.UserName = UserName.text;
        user.Password = PassWord.text;
        
        //会員登録を行う
        user.SignUpAsync ((NCMBException e) => { 
            if (e != null) {
                UnityEngine.Debug.Log ("新規登録に失敗: " + e.ErrorMessage);
            } else {
                UnityEngine.Debug.Log ("新規登録に成功");
                Application.LoadLevel ("LogOut");
            }
        });
    }
```

`Logout.cs`

```csharp
// ログアウト
public void Logout_user ()
    {
        NCMBUser.LogOutAsync ((NCMBException e) => { 
            if (e != null) {
                UnityEngine.Debug.Log ("ログアウトに失敗: " + e.ErrorMessage);
            } else {
                UnityEngine.Debug.Log ("ログアウトに成功");
                Application.LoadLevel ("Loginsignin");
            }
        });

    }
```

## 参考
* ニフティクラウドmobile backend の[ドキュメント（会員管理）](http://mb.cloud.nifty.com/doc/current/user/basic_usage_unity.html)
