     public class TreeViewA : TreeView {
    
        public new static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(TreeViewA), new FrameworkPropertyMetadata(null, OnSelectedItemChanged));
    
        public TreeViewA() {
          base.SelectedItemChanged += this.OnTreeViewSelectedItemChanged;
          this.ItemContainerGenerator.StatusChanged += this.ItemContainerGeneratorOnStatusChanged;
        }
    
        public new object SelectedItem {
          get {
            return this.GetValue(SelectedItemProperty);
          }
          set {
            this.SetValue(SelectedItemProperty, value);
          }
        }
    
        private void ItemContainerGeneratorOnStatusChanged(object sender, EventArgs eventArgs) {
          if (this.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
            return;
          if (this.SelectedItem != null) {
            this.VisualSelectItem();
          }
        }
    
        private void VisualSelectItem() {
          var xx = (TreeViewItem)this.ItemContainerGenerator.ContainerFromItem(this.SelectedItem);
          if (xx == null)
            return;
          xx.IsSelected = true;
          xx.BringIntoView();
        }
    
        private void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e) {
          this.SelectedItem = e.NewValue;
        }
    
        private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
          if (e.NewValue != null) {
            (sender as TreeViewA)?.VisualSelectItem();
          }
        }
    
      }
