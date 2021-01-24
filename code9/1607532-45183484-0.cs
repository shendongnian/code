    public FindStudies_DTO_OUT FindStudies(FindStudies_DTO_IN findStudies_DTO_IN)
        {
            var token = Token;
            List<Study_C> ret = new List<Study_C>();
            _dispatcherCallBack = OperationContext.Current.GetCallbackChannel<IDispatcherCallBack>();
            AnnuncedFindStudies += (s, e) =>
            {
                _dispatcherCallBack.OnAnnounceFindStudies(e);
            };
            AnnuncedSPError += (s, e) =>
            {
                _dispatcherCallBack.OnAnnunceSPError(e);
            };
            AnnuncedComplete += (s, e) =>
            {
                _dispatcherCallBack.OnAnnunceComplete();
            };
            Task.Run(() =>
            {
                //Blah blah
                if (proxyGetError)
                    OnAnnuncedSPError(new SPError_DTO()
                    {
                        ServicePointName = sp.Name,
                        ErrorMessage = "Ping failed for " + sp.Name
                    });
                var result = new List<Study_C>();//Filled
                lock (ret)
                {
                    OnAnnounceFindStudies(new FindStudies_DTO()
                    {
                        ServicePointName = sp.Name,
                        Studies = result
                    }); 
                }
                //blah blah
                OnAnnounceComplete();
            });
            return new FindStudies_DTO_OUT();
        }
