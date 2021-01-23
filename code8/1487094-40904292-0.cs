        using (WebClient wc = new WebClient())
    {
    	wc.Headers[HttpRequestHeader.Cookie] = "SessionID=" + Request.Cookies["SessionID"].Value;
    	Stream _stream= wc.OpenRead("http://localhost/Employee/finance_util.asp?function=GetSalary&EmpId=12345");
    	StreamReader sr= new StreamReader(_stream);
    	string s = sr.ReadToEnd();
    	_stream.Close();
    	sr.Close();
    }
