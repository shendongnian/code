               string ClientUrl = Request.Url.AbsoluteUri;               
                string[] vUrlArray = ClientUrl.Split('/');
                if (vUrlArray.Count() >= 6)
                {
                    ClientUrl = "";
                    for (int i = 0; i <= 4; i++)
                    {
                        ClientUrl = ClientUrl + vUrlArray[i] + "/";
                    }
                    ClientUrl = ClientUrl.Substring(0, UrlDoCliente.LastIndexOf("/"));              
                }     
