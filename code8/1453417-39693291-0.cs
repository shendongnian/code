    protected override async void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      _userData = ServiceLocator.GetService<IAuthService>().GetUserData();
      _wallsViewPresenter = ViewPresenterHelper.CreateViewPresenter<WallViewPresenter, IWallView, WallActivity>(this);
      _listView = FindViewById<ListView>(Resource.Id.postList);
      progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);
      profile = await _wallsViewPresenter.GetProfile(int.Parse(_userData.Profile));
      WallModel wall = SerializationService.DeSerialize<WallModel>(profile.Wall);
      _posts = (List<PostModel>) (wall.Posts.ToList());                        
      progressBar.Visibility = ViewStates.Gone;
      _postListAdapter = new PostListAdapter(this, _posts);
      _listView.Adapter = _postListAdapter;
      SetListViewHeader();
      _listView.AddHeaderView(_header);
      FindViewById<TextView>(Resource.Id.details).Text = profile.Name;
    }
