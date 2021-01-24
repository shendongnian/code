            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
    
                try
                {
                    View view = inflater.Inflate(Resource.Layout.recycleview, container, false);
    
                    mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
    
                    mLayoutManager = new LinearLayoutManager(this.Activity);
                    mRecyclerView.SetLayoutManager(mLayoutManager);
                }
                catch (Exception)
                {
    
                    Log.WriteLine(LogPriority.Debug, "EXception from fragment inside OnCreateView", e.Message);
                }
    
              
                
            }
    
            public async override void OnResume()
            {
                base.OnResume();
                // Prepare the data source:
                try
                {
                    using (var client = new HttpClient())
                    {
                        var uri = "jsonplaceholder.typicode.com/posts";
                        var result = await client.GetStringAsync(uri);
                        var Restresponse = JsonConvert.DeserializeObject<List<Restresponse>>(result);
                        mAdapter = new RecycleViewAdapter(Restresponse, this.Activity);
                        mRecyclerView.SetAdapter(mAdapter);
                    }
                }
                catch (System.Exception e)
                {
                    Log.WriteLine(LogPriority.Debug, "EXception from fragment inside OnResume", e.Message);
                }
            }
