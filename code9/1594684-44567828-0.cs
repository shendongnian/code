    public class MyItemsControl : ItemsControl
    {
        public MyItemsControl()
        {
            DependencyPropertyDescriptor dpd = DependencyPropertyDescriptor
                .FromProperty(ItemsControl.ItemsSourceProperty, typeof(ItemsControl));
            if (dpd != null)
            {
                dpd.AddValueChanged(this, OnMyItemsSourceChange);
            }
        }
        private void OnMyItemsSourceChange(object sender, EventArgs e)
        {
            //...
        }
    }
