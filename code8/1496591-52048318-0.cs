    public class DummyPageModel : FreshBasePageModel
    {
        private object _data;
        private bool _isPushed = true;
        public override void Init(object initData) =>  _data = initData;
        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            if (_isPushed)
            {
                _isPushed = false;
                await CoreMethods.PushPageModel<StorePageModel>(_data);
            }
            else
            {
                await CoreMethods.PopPageModel();
            }
        }
    }
