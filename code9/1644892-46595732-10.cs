    public class MyComboBox : ComboBox
    {
        public MyComboBox()
        {
            this.DefaultStyleKey = typeof(MyComboBox);
        }
    
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
    
            var itemsPresenter = GetTemplateChild("Ip1") as UIElement;
    
            if (itemsPresenter != null)
                itemsPresenter.KeyUp += ItemsPresenter_KeyUp;
                
        }
    
        private void ItemsPresenter_KeyUp(object sender, KeyEventArgs e)
        {
            SelectedItem = e.OriginalSource;
        }
    }
