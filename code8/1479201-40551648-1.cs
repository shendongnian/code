            //read the info
            using (StreamReader st = new StreamReader(res.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = st.ReadToEnd();
                TwitterObject tn = js.Deserialize<TwitterObject>(objText);
                foreach (var item in tn.results)
                {
                    Response.Write(item.name.first + item.name.last + "<br />");
                }
            }
