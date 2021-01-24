    BackgroundWorker bworker;
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        //Inflate the fragment XML
        View view = inflater.Inflate(Resource.Layout.FragmentSettings, container, false);
        //Grab the butten from the inflated fragment
        mBtnOk = view.FindViewById<Button>(Resource.Id.mBtnOk);
        mBtnOk.Click += (object sender, EventArgs e) =>
        {
            //DO stuff
        };
        //Start background task
        bworker = new BackgroundWorker();
        bworker.DoWork += Bworker_DoWork;
        bworker.RunWorkerCompleted += Bworker_RunWorkerCompleted;
        bworker.RunWorkerAsync();
        return view;
    }
    private void Bworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {   
       //Do stuff when the operation is completed
        bworker.RunWorkerAsync();
    }
    private void Bworker_DoWork(object sender, DoWorkEventArgs e)
    {
        //Do the work in the background
    }
