    public class BTextBox : ItemsControl {
    
        static BTextBox() {
          DefaultStyleKeyProperty.OverrideMetadata(typeof(BTextBox), new FrameworkPropertyMetadata(typeof(BTextBox)));
        }
    
        private TextBox _textBox;
        private ItemsControl _itemsView;
    
        public static readonly DependencyProperty ProviderCommandProperty = DependencyProperty.Register("ProviderCommand", typeof(ICommand), typeof(BTextBox), new PropertyMetadata(null));
        public static readonly DependencyProperty AutoItemsSourceProperty = DependencyProperty.Register("AutoItemsSource", typeof(IEnumerable), typeof(BTextBox), new PropertyMetadata(null, OnItemsSourceChanged));
    
        public IEnumerable AutoItemsSource {
          get {
            return (IEnumerable)GetValue(AutoItemsSourceProperty);
          }
          set {
            SetValue(AutoItemsSourceProperty, value);
          }
        }
    
        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
          var tb = d as BTextBox;
          if ((e.NewValue != null) && ((tb.ItemsSource as IList) != null)) {
            foreach (var item in e.NewValue as IEnumerable) {
              (tb.AutoItemsSource as IList).Add(item);
            }
    
          }
        }
    
        public override void OnApplyTemplate() {
          this._textBox = this.GetTemplateChild("PART_TextBox") as TextBox;
          this._itemsView = this.GetTemplateChild("PART_ListBox_Sugg") as ItemsControl;
          this._itemsView.ItemsSource = this.AutoItemsSource;
          this._textBox.TextChanged += (sender, args) => {
            this.ProviderCommand?.Execute(this._textBox.Text);
          };
    
          base.OnApplyTemplate();
        }
    
        public ICommand ProviderCommand {
          get {
            return (ICommand) this.GetValue(ProviderCommandProperty);
          }
          set {
            this.SetValue(ProviderCommandProperty, value);
          }
        }
    
        public ICommand AddCommand {
          get {
            return new RelayCommand(obj => {
              (this.ItemsSource as IList)?.Add(obj);
            });
          }
        }
    
      }
