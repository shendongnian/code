     public partial class LabelAndTextbox : UserControl
        {
            /// <summary>
            /// Gets or sets the Label which is displayed next to the field
            /// </summary>
            public String Label
            {
                get { return (String)GetValue(LabelContent); }
                set { SetValue(LabelContent, value); }
            }
    
            /// <summary>
            /// Identified the Label dependency property
            /// </summary>
            public static readonly DependencyProperty LabelContent =
                DependencyProperty.Register("Label", typeof(string),
                  typeof(LabelAndTextbox), new PropertyMetadata(""));
    
            public object Text
            {
                get { return (object)GetValue(TextProperty); }
                set { SetValue(TextProperty, value); }
            }
    
    
            public static readonly DependencyProperty TextProperty =
                DependencyProperty.Register("Text", typeof(object),
                  typeof(LabelAndTextbox), new PropertyMetadata(null));
    
            public Double LabelWidth
            {
                get { return (Double)GetValue(LabelWidthProperty); }
                set { SetValue(LabelWidthProperty, value); }
            }
    
            public static readonly DependencyProperty LabelWidthProperty =
                DependencyProperty.Register("LabelWidth", typeof(Double),
                    typeof(LabelAndTextbox), new PropertyMetadata());
    
            public Double TextboxWidth
            {
                get { return (Double)GetValue(TextboxWidthProperty); }
                set { SetValue(TextboxWidthProperty, value); }
            }
    
            public static readonly DependencyProperty TextboxWidthProperty =
               DependencyProperty.Register("TextboxWidth", typeof(Double),
                     typeof(LabelAndTextbox), new PropertyMetadata());
    
            public bool TextboxReadOnly
            {
                get { return (bool)GetValue(TextboxReadOnlyProperty); }
                set { SetValue(TextboxReadOnlyProperty, value); }
            }
    
    
            public static readonly DependencyProperty TextboxReadOnlyProperty =
                DependencyProperty.Register("TextboxReadOnly", typeof(bool),
                  typeof(LabelAndTextbox), new FrameworkPropertyMetadata());
    
            public HorizontalAlignment TextboxHorizontalContentAlgnment
            {
                get { return (HorizontalAlignment)GetValue(TextboxHorizontalContentAlgnmentProperty); }
                set { SetValue(TextboxHorizontalContentAlgnmentProperty, value); }
            }
    
    
            public static readonly DependencyProperty TextboxHorizontalContentAlgnmentProperty =
                DependencyProperty.Register("TextboxHorizontalContentAlgnment", typeof(HorizontalAlignment),
                  typeof(LabelAndTextbox), new FrameworkPropertyMetadata());
    
            public LabelAndTextbox()
            {
                InitializeComponent();
            }
        }
