    string WebGet()
    {
        Response result = new Response();
        IEnumerator e = GetStuff(result);
		// blocks here until UnityWebRequest() completes
        while (e.MoveNext());
        Debug.Log(result.result);
    }
    public class Response
    {
        public string result = "";
    }
    IEnumerator GetStuff(Response res)
    {
        UnityWebRequest www = UnityWebRequest.Get("http://some.add.com/");
        yield return www.SendWebRequest();
        while (!www.isDone)
            yield return true;
        if (www.isNetworkError || www.isHttpError)
            res.result = www.error;
        else
            res.result = www.downloadHandler.text;
    }
