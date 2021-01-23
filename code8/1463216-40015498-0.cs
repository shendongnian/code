    string strdocPath;
            try
            {
                strdocPath = (Server.MapPath("~\\Uploads\\" + DocumentName));
                FileStream objfilestream = new FileStream(strdocPath, FileMode.Open, FileAccess.Read);
                int len = (int)objfilestream.Length;
                Byte[] documentcontents = new Byte[len];
                objfilestream.Read(documentcontents, 0, len);
                objfilestream.Close();
                string result = Convert.ToBase64String(documentcontents);
                return result;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
