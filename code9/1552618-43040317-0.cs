    public class PagingComboBox : ComboBox {
    
        public PagingComboBox() {
          this.ItemsSource = new ObservableCollection<object>();
          this.Loaded += this.MyComboboxLoaded;
        }
    
        private int _currentItems = 0;
        private void MyComboboxLoaded(object sender, RoutedEventArgs e) {
          for (int i=0; i < this.PageSize; i++)
          {
            (this.ItemsSource as ObservableCollection<object>).Add(this.PagingSource[i]);
            this._currentItems++;
          }
    
          var sv = this.Template.FindName("DropDownScrollViewer", this) as ScrollViewer;
          sv.ScrollChanged += this.SvScrollChanged;
          
        }
    
        private void SvScrollChanged(object sender, ScrollChangedEventArgs e) {
          var sv = sender as ScrollViewer;
          var isAtEnd = sv.VerticalOffset == sv.ScrollableHeight;
          var cLimmit = this._currentItems + this.PageSize;
          if (isAtEnd && this._currentItems < this.PagingSource.Count) {
            for (int i = this._currentItems; i < cLimmit; i++)
            {
              if (i > this.PagingSource.Count - 1) return;
              (this.ItemsSource as ObservableCollection<object>).Add(this.PagingSource[i]);
              this._currentItems++;
            }
          }
        }
    
        public int PageSize {
          get {
            return (int)GetValue(PageSizeProperty);
          }
          set {
            SetValue(PageSizeProperty, value);
          }
        }
    
        // Using a DependencyProperty as the backing store for PageSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageSizeProperty =
            DependencyProperty.Register("PageSize", typeof(int), typeof(PagingComboBox), new PropertyMetadata(20));
    
    
    
        public IList PagingSource {
          get {
            return (IList)GetValue(PagingSourceProperty);
          }
          set {
            SetValue(PagingSourceProperty, value);
          }
        }
    
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PagingSourceProperty =
            DependencyProperty.Register("PagingSource", typeof(IList), typeof(PagingComboBox), new PropertyMetadata(null));
    
    
    
      }
