    using UnityEngine;
    using System.Collections;
    using UnityEngine.Networking;
    
    public class Test : MonoBehaviour
    {
    
        CustomWebRequest camImage;
        UnityWebRequest webRequest;
        byte[] bytes = new byte[90000];
    
        void Start()
        {
            string url = "http://camUrl/mjpg/video.mjpg";
            webRequest = new UnityWebRequest(url);
            webRequest.downloadHandler = new CustomWebRequest(bytes);
            webRequest.Send();
        }
    }
