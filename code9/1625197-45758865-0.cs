    string[] obj = new string[5] {"hi","en","ar","or","xy" };            
            string urlString = Request.RawUrl.ToLower();
            int location = 0;
            for (int i = 0; i < obj.Length; i++)
            {
                if (urlString.Contains("=" + obj[i]))
                {
                    location = i;
                    break;
                }
            }
            string strNewURL = Request.RawUrl.ToLower().Replace("ln=" + obj[location], "");
            Response.Redirect(strNewURL);
