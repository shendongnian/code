        public bool InsertData(List<MachineInfo> MachineInfo, string flag,int userID)
        {
            if (MachineInfo != null && flag != string.Empty)
            {
                List<T> attList = new List<T>();
                foreach (var item in MachineInfo)
                {
                    T att = new T()
                    {
                        CreatedDate = DateTime.Now,
                        DateTime = item.DateTimeRecord,
                        EnrollNumber = item.EnrollNumber.ToString(),
                        IPFlag = flag,
                        SyncBy = userID
                    };
                    attList.Add(att);
                }
                try
                {
                    Entities context = null;
                    try
                    {
                        context = new Entities();
                        context.Configuration.AutoDetectChangesEnabled = false;
                        int count = 0;
                        foreach (var entity in attList)
                        {
                            ++count;
                            context = AddToContext(context, entity, count, 100, true);
                        }
                        context.SaveChanges();
                    }
                    finally
                    {
                        if (context != null)
                            context.Dispose();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
