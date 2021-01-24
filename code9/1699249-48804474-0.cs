    public class ScaleItemsControl : ItemsControl
    {
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            ScaleItems();
        }
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            ScaleItems();
        }
        private void ScaleItems()
        {
            foreach (var item in ItemsSource.OfType<IScalableVm>())
            {
                item.Scale(this.RenderSize.Width, this.RenderSize.Height);
            }
        }
    }
