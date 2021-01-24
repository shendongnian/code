    using System.Collections;
    using System.IO;
    using UnityEngine;
    using UnityEngine.Networking;
    
    public class FileDownloader : MonoBehaviour {
    
        void Start () {
            StartCoroutine(DownloadFile());
        }
        
        IEnumerator DownloadFile() {
            var uwr = new UnityWebRequest("http://www.my-server.com/myData.unity3d", UnityWebRequest.kHttpVerbGET);
            string path = Path.Combine(Application.persistentDataPath, "myData.unity3d");
            uwr.downloadHandler = new DownloadHandlerFile(path);
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError || uwr.isHttpError)
                Debug.LogError(uwr.error);
            else {
                // !!! <-- Now we have a path to the downloaded asset
                Debug.Log("File successfully downloaded and saved to " + path);
                var myLoadedAssetBundle = AssetBundle.LoadFromFile(path); 
                
                // Matches some 'Resources/MyObject.prefab'
                var prefab = myLoadedAssetBundle.LoadAsset.<GameObject>("MyObject");
                Instantiate(prefab);
            }             
        }
    }
