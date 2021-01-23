    private void tabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl tc = sender as TabControl;
            ContentPresenter cp = tc.Template.FindName("PART_SelectedContentHost", tc) as ContentPresenter;
            if(cp != null && VisualTreeHelper.GetChildrenCount(cp) > 0)
            {
                ContentPresenter cpp = VisualTreeHelper.GetChild(cp, 0) as ContentPresenter;
                if(cpp != null)
                {
                    TextBox textBox = cpp.FindName("txt") as TextBox;
                    if (textBox != null)
                        textBox.Text = string.Empty;
                }
            }
        }
----------
        <TabControl x:Name="tabs" ItemsSource="{Binding Tabs}" SelectionChanged="tabs_SelectionChanged">
            <TabControl.ContentTemplate>
                <DataTemplate>
                    <ContentPresenter>
                        <ContentPresenter.Content>
                            <StackPanel>
                                <TextBox x:Name="txt"></TextBox>
                            </StackPanel>
                        </ContentPresenter.Content>
                    </ContentPresenter>
                </DataTemplate>
            </TabControl.ContentTemplate>
        </TabControl>
