    class CustomViewPresenter : MvxAndroidViewPresenter
    {
        public CustomViewPresenter(IEnumerable<Assembly> androidViewAssemblies)
                  : base(androidViewAssemblies)
        {
        }
    
        public override void Show(MvxViewModelRequest request)
        {
            if (request.PresentationValues.ContainsKey("something"))
            {
                //handle presentation value
            }
            base.Show(request);
        }
    }
