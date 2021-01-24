    public class WindowsMenuFlyoutItem : Windows.UI.Xaml.Controls.MenuFlyoutItem
    {
        public ICommonMenuItem InnerItem { get; set; }
        public WindowsMenuFlyoutItem(MyModelObject inner)
        {
            this.Text = inner.GetTitle().Text;
            this.Tapped += WindowsMenuFlyoutItem_Tapped;
            Windows.UI.Xaml.Controls.ToolTipService.SetToolTip(this, "tooltip...");
        }
    }
