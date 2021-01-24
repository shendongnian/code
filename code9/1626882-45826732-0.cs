    HttpWebRequest request = WebRequest.CreateHttp(server + _tempWS);
                //DataConnection getUser = GetValidUser(server);
                try
                {
                    string cook = ConfigurationManager.AppSettings["IdentityGeneratedValidToken"];
                    request.Method = "POST";
                    request.Headers.Add("Cookie", "FedAuth=" + cook);
                    request.ContentType = "application/json; charset=UTF-8";
                    request.Referer = server ;
                    string data = "{\"Pagina\":1,\"Registros\":10,\"Orden\":\"{}\",\"Filtro\":\"{  }\",\"EsInternacional\":false}";
                    byte[] postBytes = Encoding.ASCII.GetBytes(data);
                    request.ContentLength = (long)postBytes.Length;
                    request.ContentLength = 0L;
                    request.Timeout = 3000;
                }
