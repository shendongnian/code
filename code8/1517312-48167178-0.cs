    catch (System.Net.WebException ex)
    {
	    WebResponse resp = ex.Response;
	    string JiraErrorMessages = (new System.IO.StreamReader(resp.GetResponseStream(), true)).ReadToEnd();
    }
