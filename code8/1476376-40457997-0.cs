    using (UnityWebRequest www = UnityWebRequest.GetTexture("http://www.my-server.com/image.png"))
    {
        yield return www.Send();
        if (www.isError)
        {
            Debug.Log(www.error);
        }
        else
        {
            m_myTexture = DownloadHandlerTexture.GetContent(www);
        }
    }
