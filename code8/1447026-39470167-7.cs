     <TabControl>
            <TabItem Header="1">
            </TabItem>
            <TabItem Header="2">
                <local:UserControl1 IsVisibleChanged="UIElement_OnIsVisibleChanged"></local:UserControl1>
            </TabItem>
            <TabItem></TabItem>
        </TabControl>
       private void UIElement_OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
       {
           var uc = sender as UserControl1;
       }
