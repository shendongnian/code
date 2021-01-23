    HttpWebRequest itemRequest =
    	(HttpWebRequest)HttpWebRequest.Create(hostUrl + "/_api/Web/lists/getbytitle('" + listName + "')/items");
    itemRequest.Method = "POST";
    itemRequest.ContentLength = itemPostBody.Length;
    itemRequest.ContentType = "application/json;odata=verbose";
    itemRequest.Accept = "application/json;odata=verbose";
    itemRequest.Headers.Add("Authorization", "Bearer " + token);
    itemRequest.Headers.Add("X-RequestDigest", formDigest);
