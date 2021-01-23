        System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
        req.ContentType = "application/json";
        req.Method = "POST";
        string postData = @"
            {
                'Data':
                [
                    { 'field1': 'value11', 'field2': 'value12' },
                    { 'field1': 'value11', 'field2': 'value12' },
                    { 'field1': 'value11', 'field2': 'value12' }
                ]
            }";
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        req.ContentLength = byteArray.Length;
        System.IO.Stream dataStream = req.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
