    var param = "";
            var bytes = Encoding.UTF8.GetBytes(authnRequest.ToXElement().ToString());
            using (var output = new MemoryStream())
            {
                using (var zip = new DeflateStream(output, CompressionMode.Compress))
                {
                    zip.Write(bytes, 0, bytes.Length);
                }
                var base64String = Convert.ToBase64String(output.ToArray());
                param =  HttpUtility.UrlEncode(base64String);
            }
