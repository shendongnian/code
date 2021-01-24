            try
            {
                if ((fileFormName == null) ||
                    (fileFormName.Length == 0))
                {
                    fileFormName = "file";
                }
                if ((contenttype == null) ||
                    (contenttype.Length == 0))
                {
                    contenttype = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                }
                string postdata;
                postdata = "?";
                if (querystring != null)
                {
                    foreach (string key in querystring.Keys)
                    {
                        postdata += key + "=" + querystring.Get(key) + "&";
                    }
                }
                Uri uri = new Uri(url + postdata);
                string boundary = "----------" + DateTime.Now.Ticks.ToString("x");
                HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(uri);
                webrequest.CookieContainer = cookies;
                webrequest.ContentType = "multipart/form-data; boundary=" + boundary;
                webrequest.Method = "POST";
                // Build up the post message header
                StringBuilder sb = new StringBuilder();
                sb.Append("--");
                sb.Append(boundary);
                sb.Append("\r\n");
                sb.Append("Content-Disposition: form-data; name=\"");
                sb.Append(fileFormName);
                sb.Append("\"; filename=\"");
                var sd = sb.Append(Path.GetFileName(uploadfile));
                sb.Append("\"");
                sb.Append("\r\n");
                sb.Append("Content-Type: ");
                sb.Append(contenttype);
                sb.Append("\r\n");
                sb.Append("\r\n");
                string postHeader = sb.ToString();
                byte[] postHeaderBytes = Encoding.UTF8.GetBytes(postHeader);
                // Build the trailing boundary string as a byte array
                // ensuring the boundary appears on a line by itself
                byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
                FileStream fileStream = new FileStream(uploadfile, FileMode.Open, FileAccess.Read);
                long length = postHeaderBytes.Length + fileStream.Length + boundaryBytes.Length;
                //  webrequest.ContentLength = length;
                webrequest.Headers[HttpRequestHeader.ContentLength] = length.ToString();
                //Stream requestStream = webrequest.GetRequestStream();
                Stream requestStream = await webrequest.GetRequestStreamAsync();
                // Write out our post header
                requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                // Write out the file contents
                byte[] buffer = new Byte[checked((uint)Math.Min(4096, (int)fileStream.Length))];
                int bytesRead = 0;
                 while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    requestStream.Write(buffer, 0, bytesRead);
                // Write out the trailing boundary
                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                WebResponse response = await webrequest.GetResponseAsync();
                Stream s = response.GetResponseStream();
                StreamReader sr = new StreamReader(s);
                return sr.ReadToEnd();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return null;
        }
