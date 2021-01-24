            HttpCookie MyCookie = new HttpCookie("MyCookie");
            // for remveing if already Exists adding new;
            Request.Cookies.Remove("MyCookie");
            if (Request.Cookies["MyCookie"] == null)
            {
                MyCookie["id"] = id.ToString();
                Response.Cookies.Add(MyCookie);
            }
            else
            {
                MyCookie["id"] = id.ToString();
                // Request.Cookies.Remove("MyCookie");
                Response.Cookies.Set(MyCookie);
            }
            // retries 
            int id = Convert.ToInt32(Request.Cookies["MyCookie"]["id"]);
