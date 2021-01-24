    <telerik:RadRichTextBox x:Name="rtb" telerik:RadMenuItem.Click="rtb_Click" />
----------
    private void rtb_Click(object sender, RoutedEventArgs e)
    {
        Telerik.Windows.Controls.RadMenuItem item = e.OriginalSource as Telerik.Windows.Controls.RadMenuItem;
        if (item != null && item.Header != null && item.Header.ToString() == "Edit Hyperlink...")
        {
            //...
        }
    }
