    namespace MasterPages.Master
    {
      public class Master : Control
      {
        static Master()
        {
          DefaultStyleKeyProperty.OverrideMetadata(typeof(Master), 
            new FrameworkPropertyMetadata(typeof(Master)));
        }
    
        public object Title
        {
          get { return (object)GetValue(TitleProperty); }
          set { SetValue(TitleProperty, value); }
        }
    
        public static readonly DependencyProperty TitleProperty =
          DependencyProperty.Register("Title", typeof(object), 
          typeof(Master), new UIPropertyMetadata());
    
        public object Abstract
        {
          get { return (object)GetValue(AbstractProperty); }
          set { SetValue(AbstractProperty, value); }
        }
    
        public static readonly DependencyProperty AbstractProperty =
          DependencyProperty.Register("Abstract", typeof(object), 
          typeof(Master), new UIPropertyMetadata());
    
        public object Content
        {
          get { return (object)GetValue(ContentProperty); }
          set { SetValue(ContentProperty, value); }
        }
    
        public static readonly DependencyProperty ContentProperty =
          DependencyProperty.Register("Content", typeof(object), 
          typeof(Master), new UIPropertyMetadata());
      }
    }
