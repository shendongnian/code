    <GridView x:Name="gvMain" SelectionChanged="gvMain_SelectionChanged">
            <GridView.ItemsPanel>
                <ItemsPanelTemplate>
                    <local:CustomPanel></local:CustomPanel>
                </ItemsPanelTemplate>
            </GridView.ItemsPanel>
            <GridViewItem >
                <Rectangle Fill="Red" Width="50" Height="50"></Rectangle>
            </GridViewItem>
            <GridViewItem >
                <Rectangle Fill="Blue"  Width="50" Height="50" ></Rectangle>
            </GridViewItem>
            <GridViewItem>
                <Rectangle Fill="Yellow" Width="50" Height="50"></Rectangle>
            </GridViewItem>
    </GridView>
    public class CustomPanel:Canvas
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            Size s = base.MeasureOverride(availableSize);
            foreach (UIElement element in this.Children)
            {
                
                element.Measure(availableSize);
            }
            return s;
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            this.Clip = new RectangleGeometry { Rect = new Rect(0, 0, finalSize.Width, finalSize.Height) };
            Double position = 0d;
            foreach (UIElement item in this.Children)
            {
                if (item == null)
                    continue;
                Size desiredSize = item.DesiredSize;
                if (double.IsNaN(desiredSize.Width) || double.IsNaN(desiredSize.Height)) continue;
                var rect = new Rect(0, position, desiredSize.Width, desiredSize.Height);
                item.Arrange(rect);
                TranslateTransform compositeTransform = new TranslateTransform();
                compositeTransform.X = position / 2;
                item.RenderTransform = compositeTransform;
                position += desiredSize.Width;
            }
            return finalSize;
        }
    }
    private void gvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        GridViewItem item = (sender as GridView).SelectedItem as GridViewItem;
        if (item != null)
        {
            Canvas.SetZIndex(item,index);
        }
    }
