    public static class MapClient {
        public static Client ToModel(this tbl_Client source) {
            return (source != null) ? new Client {
                Id = source.Id,
                ApiKey = source.ApiKey,
                ApiURL = source.ApiURL,
                ClientKey = source.ClientKey,
                Password = source.Password,
                RetainMeApiKey = source.RetainMeApiKey,
                Secret = source.Secret
            }
            : null;
        }
    }
