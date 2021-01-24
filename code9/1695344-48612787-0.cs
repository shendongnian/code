    string url = sess.fullUrl.ToLower();
            var extensions = CaptureConfiguration.ExtensionFilterExclusions;
            foreach (var ext in extensions)
            {
                if (url.Contains(ext))
                    return;
            }
            var filters = CaptureConfiguration.UrlFilterExclusions;
            foreach (var urlFilter in filters)
            {
                if (url.Contains(urlFilter))
                    return;
            }
            // }
            if (sess == null || sess.oRequest == null || sess.oRequest.headers == null)
                return;
            string headers = sess.oRequest.headers.ToString();
            var reqBody = Encoding.UTF8.GetString(sess.RequestBody); string firstLine = sess.RequestMethod + " " + sess.fullUrl + " " + sess.oRequest.headers.HTTPVersion;
            int at = headers.IndexOf("\r\n");
            if (at < 0)
                return;
            headers = firstLine + "\r\n" + headers.Substring(at + 1);
            string output = headers + "\r\n" +
                            (!string.IsNullOrEmpty(reqBody) ? reqBody + "\r\n" : string.Empty) +
                            Separator + "\r\n\r\n";
            // must marshal to UI thread
            BeginInvoke(new Action<string>((text) =>
           {
               txtCapture.AppendText(text);
               UpdateButtonStatus();
           }
            ), output);
