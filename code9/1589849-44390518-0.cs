        public override object this[string key]
        {
            get
            {
                if (Helpers.CommonFunctions.IsHttpSessionNull)
                { return null; }
                lock (HttpContext.Current.Session)
                { 
                    return HttpContext.Current.Session[key + Helpers.CommonFunctions.GetAppDomainMultiplexer()];
                }
            }
            set
            {
                if (Helpers.CommonFunctions.IsHttpSessionNull)
                { return; }
                lock (HttpContext.Current.Session)
                {
                    if (value == null)
                    {
                        try
                        {
                            if (HttpContext.Current.Session[key + Helpers.CommonFunctions.GetAppDomainMultiplexer()] != null)
                            {
                                HttpContext.Current.Session.Remove(key + Helpers.CommonFunctions.GetAppDomainMultiplexer());
                            }
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        HttpContext.Current.Session[key + Helpers.CommonFunctions.GetAppDomainMultiplexer()] = value;
                    }
                }
            }
