    public void EThread()
    {
        string StrID;
        while(!_RequiredIDs.IsEmpty)
           if (_RequiredIDs.TryDequeue(out StrID))
           {
               HttpWebRequest HWRequest = (HttpWebRequest)WebRequest.Create(_AjaxURL);
               HWRequest.Method = "POST";
               HWRequest.ContentType = "text/xml; encoding='utf-8'";
               Extract(StrID, ref HWRequest);
           }
    }
