    public void EThread()
    {
        HttpWebRequest HWRequest = (HttpWebRequest)WebRequest.Create(_AjaxURL);
        HWRequest.Method = "POST";
        HWRequest.ContentType = "text/xml; encoding='utf-8'";
        string StrID;
        while(!_RequiredIDs.IsEmpty)
           if (_RequiredIDs.TryDequeue(out StrID))
           {
               Extract(StrID, ref HWRequest);
               HWRequest.Reset();
           }
    }
