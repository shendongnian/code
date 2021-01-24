    protected void Get_Click(object sender, EventArgs e){
    HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(txUrl.Text);
    // get the response
    HttpWebResponse WebResp = (HttpWebResponse)wr.GetResponse();
    string res = "";
    using (StreamReader sr = new StreamReader(WebResp.GetResponseStream()))
    {
        res = sr.ReadToEnd();
        sr.Close();
    }
               
    WebResp.Close();
    
    txHTML.Text = res;
    }
