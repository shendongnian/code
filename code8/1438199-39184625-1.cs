     public class CustomRepeater : StackLayout
    {
        /// <summary>
        ///  The Item template property
        /// </summary>
        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(CustomRepeater), null, propertyChanged: (bindable, oldvalue, newvalue) => ((CustomRepeater)bindable).OnSizeChanged());
        
      
        /// <summary>
        /// Gets or sets the item template
        /// </summary>
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { this.SetValue(ItemTemplateProperty, value); }
        }
        public void OnSizeChanged()
        {
            this.ForceLayout();
        }
        
        public ScrollView RootScrollView { private set; get; }
        public StackLayout MainStackLayout { private set; get; }
        
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            
            Children.Clear();
            RootScrollView = new ScrollView();
            MainStackLayout = new StackLayout();
            MainStackLayout.Children.Clear();
            IList list =BindingContext as IList;
            if (list != null)
            {
                foreach (var i in list)
                {
                    var child = this.ItemTemplate.CreateContent() as View;
                    if (child == null)
                    {
                        return;
                    }
                    child.BindingContext = i;
                    MainStackLayout.Children.Add(child);
                }               
                
                Children.Add(MainStackLayout);
            }
        }
