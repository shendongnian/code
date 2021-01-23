        protected string GetToken(string generateTokenUrl,string username,string password)
        {
            try
            {
                string ipadress = _serverInformationHelper.GetIPAddress();
                int exp = 60;
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    Model.Arcgis.TokenModel tokenModel = new Model.Arcgis.TokenModel(username, password, ipadress, exp);
                    
                    //token bilgisinin alınacağı server url'i
                    string post = tokenModel.GetQueryStringParameter();
                    WebClient clientToken = new WebClient();
                    clientToken.Headers.Add("Content-Type: application/x-www-form-urlencoded");
                    string tokenResult = clientToken.UploadString(generateTokenUrl, post);
                    ArcgisTokenResponseModel resultTokenModel = _seriliazer.Deserialize<ArcgisTokenResponseModel>(tokenResult);
                    if (resultTokenModel != null && !string.IsNullOrEmpty(resultTokenModel.token))
                        return resultTokenModel.token;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
