    private void Image_Tapped(object sender, TappedRoutedEventArgs e)
    {
        Image image = sender as Image;
        Panel parent = image.Parent as Panel;
        if (parent != null)
        {
            image.RenderTransform = new ScaleTransform() { ScaleX = 2, ScaleY = 2 };
            parent.Children.Remove(image);
            parent.Children.Add(new Popup() { Child = image, IsOpen = true, Tag = parent });
        }
        else
        {
            Popup popup = image.Parent as Popup;
            popup.Child = null;
            Panel panel = popup.Tag as Panel;
            image.RenderTransform = null;
            panel.Children.Add(image);
        }
    }
----------
    <GridView SelectionMode="None" isItemClickEnabled="True">
        <GridView.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Image Source="ms-appx:///Assets/pic.png" Tapped="Image_Tapped" Stretch="None" />
                </Grid>
            </DataTemplate>
        </GridView.ItemTemplate>
    </GridView>
