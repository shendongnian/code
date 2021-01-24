        string s = "";
        ParseQuery<ParseObject> query = ParseObject.GetQuery("test");
        query.GetAsync(ID).ContinueWith(t =>
        {
            ParseObject nzk = t.Result;
            Console.WriteLine(nzk.Get<string>("link"));  // this works 
            s = nzk.Get<string>("link");// this doesn't work 
        }).Wait();
        return s;
