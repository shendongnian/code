    using UnityEngine;
    using UnityEngine.Networking;
    using System.Collections;
     
    public class MyBehaviour : MonoBehaviour {
        void Start() {
            StartCoroutine(GetAssetBundle());
        }
     
        IEnumerator GetAssetBundle() {
            UnityWebRequest www = UnityWebRequest.GetAssetBundle("http://www.my-server.com/myData.unity3d");
            yield return www.SendWebRequest();
     
            if(www.isNetworkError || www.isHttpError) {
                Debug.Log(www.error);
            }
            else {
                // !!!!!! <--- Notice we do not load the asset bundle from file.
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
            }
        }
    }
