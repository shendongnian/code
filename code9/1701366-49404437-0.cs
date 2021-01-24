                static Object LockMulti = new Object();
    
                lock (LockMulti)
                {
                  -- Application specific variables/Static Variables Code Here
                }
    
                private static void GetPayTypes()
                {
                    lock (LockMulti)
                    {
                      HttpContext.Current.Application["PayTypeMaster"] = DBFactory.GetMasters(null, "GetPayTypes");
                    }
                }
