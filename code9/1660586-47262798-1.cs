        public static List<string> GetMyDocumentsPathAllUsers()
        {
            const string parcialSubkey = @"\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders";
            string subkey = string.Empty;
            const string keyName = "Personal";
            //get sids
            List<string> sids = GetMachineSids();
            List<string> myDocumentsPaths = new List<string>();
            if (sids != null)
            {
                foreach (var sid in sids)
                {
                    //get paths                  
                    subkey = sid + parcialSubkey;
                    using (RegistryKey key = Registry.Users.OpenSubKey(subkey))
                    {
                        if (key != null)
                        {
                            Object o = key.GetValue(keyName);
                            if (o != null)
                            {
                                myDocumentsPaths.Add(o.ToString());
                            }
                        }
                    }
                }
            }
            return myDocumentsPaths.Count > 0 ? myDocumentsPaths : null;
        }
