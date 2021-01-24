        public async override void OnResume()
        {
            base.OnResume();
            try
            {
                listItem = RefreshDataAsync().Result;
                // Instantiate the adapter and pass in its data source:
                mAdapter = new RecycleViewAdapter(listItem, this.Activity);
                // Plug the adapter into the RecyclerView:
                mRecyclerView.SetAdapter(mAdapter);
            }
            catch (System.Exception e)
            {
                Log.WriteLine(LogPriority.Debug, "EXception from fragmenbt", e.Message);
            }
        } 
