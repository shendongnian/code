    public class CustomViewPresenter : MvxWindowsViewPresenter
    {
        public CustomViewPresenter(IMvxWindowsFrame rootFrame) : base(rootFrame)
        {
        }
    
        public override void Show(MvxViewModelRequest request)
        {
            if (request.PresentationValues.ContainsKey("someKey"))
            {
                //handle presentation value
            }
            base.Show(request);
        }
    }
