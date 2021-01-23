    Take a look on this code. I manged to call it from fragment, i only had to set the context properly otherwise i got this error "Window.getLayoutInflater()' on a null object reference".
    
    
    
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
    
                var view = inflater.Inflate(Resource.Layout.TagDialog, container, false);
                Button confirmBtn = view.FindViewById<Button>(Resource.Id.ConfirmBtn);
                Button cancelBtn = view.FindViewById<Button>(Resource.Id.CancelBtn);
    
                AbsenceService service = new AbsenceService();
                ListViewTags = view.FindViewById<ListView>(Resource.Id.TagListView);
                TagItems = service.GetTags(1);
                ListViewTags.Adapter = new Cards_TagListAdapter(context, TagItems);
    
                // "Cancel" click
                cancelBtn.Click += delegate {
                    Dismiss();
                };
                
                confirmBtn.Click += ConfirmBtn_Click;
                return view;
            }
