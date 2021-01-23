    public partial class CustomUiToolbar : UIToolbar
    {
        public CustomUiToolbar (IntPtr handle) : base (handle)
        {
            var _UIBarButtonItemArrayOne = new UIBarButtonItem[3];
            for (int i = 0; i < 3; i++)
            {
                var _item = new UIBarButtonItem(i.ToString(), UIBarButtonItemStyle.Done, null);
                _item.TintColor = UIColor.Red;
                _UIBarButtonItemArrayOne[i] = _item;
            }
            //var __UIBarButtonItemArrayTwo = new UIBarButtonItem[2];
            //for (int i = 0; i < 2; i++)
            //{
            //    var _item = new UIBarButtonItem(i.ToString(), UIBarButtonItemStyle.Done, null);
            //    _item.TintColor = UIColor.Blue;
            //    __UIBarButtonItemArrayTwo[i] = _item;
            //}
            SetItems(_UIBarButtonItemArrayOne, true);
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
           
        }
    }
