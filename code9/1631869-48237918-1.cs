     public ServiceResult<ExternalTokenView> LoginExternal(string requestCode,ApplicationType appType)
        {
            var res = new ServiceResult<ExternalTokenView>();
            var getTokenParams = new List<KeyValuePair<string, string>>();
            getTokenParams.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
            getTokenParams.Add(new KeyValuePair<string, string>("code", requestCode));
            getTokenParams.Add(new KeyValuePair<string, string>("client_id", ClientIds[appType.ToString()]));
            if (appType == ApplicationType.AppAndroid)
                getTokenParams.Add(new KeyValuePair<string, string>("client_secret", ClientSecrets[appType.ToString()]));
            var getTokenUrl = TokenEndpoint;
            var response = HttpHelper.CallService<ExternalTokenView>(getTokenUrl, "Post", null, rowData: getTokenParams.ToArray());
            res.Data = response.Data;
            res.Status = response.Status;
            return res;
        }
