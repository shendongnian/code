    IEnumerator Post(string b)
    {
    
        byte[] bytes = System.Text.Encoding.ASCII.GetBytes(b);
    
        using (UnityWebRequest www = new UnityWebRequest(BASE_URL, UnityWebRequest.kHttpVerbPOST))
        {
            UploadHandlerRaw uH = new UploadHandlerRaw(bytes);
            DownloadHandlerBuffer dH = new DownloadHandlerBuffer();
    
            www.uploadHandler = uH;
            www.downloadHandler = dH;
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.Send();
    
            if (www.isError)
            {
                Debug.Log(www.error);
            }
            else
            {
                lbltext.text = "User Registered";
                Debug.Log(www.ToString());
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
