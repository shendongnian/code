    IEnumerator WWWClass()
        {
            string url1 = "xyz.com";
            string url2 = "xyzzz.com";
            WWW www = new WWW(url);
            yield return www;
            if (www.error == null)
            {
                //sucess
            }
            else {
                //unscuess
                www = new WWW(url2);
                yield return www;
                if (www.error == null)
                {
                    //sucess
                }
                else {
                    //unscuess
                }
            }
        }
