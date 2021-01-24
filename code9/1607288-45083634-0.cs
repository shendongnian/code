    private byte[] GetPhoto()
                {
                    try
                    {
                        var _fb = new FacebookClient(Session["FbuserToken"].ToString());
                        dynamic resultMe = _fb.Get(GetProfileId()+"?fields=picture.width(480).height(480)");
    
                    WebClient webClient = new WebClient();
                    string urlPicture = resultMe.picture.data.url;
    
                    return webClient.DownloadData(urlPicture);
    
                }
    
                catch (Exception)
                {
    
                    return null;
                }
    
            }
