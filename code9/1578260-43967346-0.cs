        public long GetDriveSpaceUsage()
        {
            try
            {
                AboutResource.GetRequest ag = new AboutResource.GetRequest(_CurrentDriveService);
                ag.Fields = "user,storageQuota";
                var response = ag.Execute();
                if (response.StorageQuota.Usage.HasValue)
                {
                    return response.StorageQuota.Usage.Value;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return -1;
            }
        }
        public long GetDriveSpaceLimit()
        {
            try
            {
                AboutResource.GetRequest ag = new AboutResource.GetRequest(_CurrentDriveService);
                ag.Fields = "user,storageQuota";
                var response = ag.Execute();
                if (response.StorageQuota.Limit.HasValue)
                {
                    return response.StorageQuota.Limit.Value;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return -1;
            }
           
        }
