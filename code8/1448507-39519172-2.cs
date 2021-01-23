    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    using System.Windows.Markup;
    namespace ThumbTest
    {
        [ContentProperty("Content")]
        public partial class MyThumb : Thumb
        {
            public MyThumb()
            {
                InitializeComponent();
            }
            #region Content Property
            public Object Content
            {
                get { return (Object)GetValue(ContentProperty); }
                set { SetValue(ContentProperty, value); }
            }
            public static readonly DependencyProperty ContentProperty =
                DependencyProperty.Register("Content", typeof(Object), typeof(MyThumb),
                    new PropertyMetadata(null));
            #endregion Content Property
        }
    }
