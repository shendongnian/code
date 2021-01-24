    var title = title_entry.Text;
    var details= details_entry.Text;
    string URI = "http://xxxxxxxxxxxx.aspx";
    String myParameters  = String.Format("title={0}&details={1}",title,details);
    sendData(URI,myParameters);
    public async void sendData(string URI,string myParameters)
    {
     using(HttpClient hc = new HttpClient())
     {
        Var response = await hc.PostAsync(URI,new StringContent (myParameters));
     }
    }
