    void DownloadFile(string url)
     {
         StartCoroutine(downloadFileCOR(url));
     }
    
     IEnumerator downloadFileCOR(string url)
     {
         UnityWebRequest www = UnityWebRequest.Get(url);
    
         yield return www.Send();
         if (www.isError)
         {
             Debug.Log(www.error);
         }
         else
         {
             Debug.Log("File Downloaded: " + www.downloadHandler.text);
    
             // Or retrieve results as binary data
             byte[] results = www.downloadHandler.data;
         }
     }
