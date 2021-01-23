      public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                switch (position)
                {
                    case 0:
                        view = (ViewGroup)inflater.Inflate(Resource.Layout.Page1, container, false);
                        break;
                    case 1:
                        view = (ViewGroup)inflater.Inflate(Resource.Layout.Page2, container, false);
                        btn_forexample = view.FindViewById<Button>(Resource.Id.btn_forexample);
                        break;
                    case 2:
                        view = (ViewGroup)inflater.Inflate(Resource.Layout.Page3, container, false);
                        break;
                    default:
                        view = (ViewGroup)inflater.Inflate(Resource.Layout.DefaultPage, container, false);
                        break;
                }
    
                return view;
            }
