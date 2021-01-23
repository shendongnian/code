    private void button4_Click(object sender, EventArgs e)
    {
        HttpWebRequest req =
        WebRequest.Create("http://test.com/contact_ip.txt") as HttpWebRequest;
        HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
        using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
        {
            string ResponseText = sr.ReadToEnd();
            //ResponseText
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = @".\\folder\\test.exe";
            proc.StartInfo.Arguments = "127.0.0.1 4455";
            proc.Start();
        }
    }
