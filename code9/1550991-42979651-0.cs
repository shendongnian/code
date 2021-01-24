        public VersionInfo GetVersionInfo(JObject jobject, string jObjectField, ref bool found)
        {
            if(jobject[jObjectField] != null)
            {
                _livetv.SoftwareVersion = new VersionInfo(jobject[jObjectField].Value<string>());
                found = true;
            }
            else
            {
                return null;
            }
        }
