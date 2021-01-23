    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    namespace HollowEarth.Controls
    {
        public class IconPopupButton : ContentControl
        {
            static IconPopupButton()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(IconPopupButton), new FrameworkPropertyMetadata(typeof(IconPopupButton)));
            }
            #region IconData Property
            public Geometry IconData
            {
                get { return (Geometry)GetValue(IconDataProperty); }
                set { SetValue(IconDataProperty, value); }
            }
            public static readonly DependencyProperty IconDataProperty =
                DependencyProperty.Register("IconData", typeof(Geometry), typeof(IconPopupButton),
                    new PropertyMetadata(null));
            #endregion IconData Property
            #region IconFill Property
            public Brush IconFill
            {
                get { return (Brush)GetValue(IconFillProperty); }
                set { SetValue(IconFillProperty, value); }
            }
            public static readonly DependencyProperty IconFillProperty =
                DependencyProperty.Register("IconFill", typeof(Brush), typeof(IconPopupButton),
                    new PropertyMetadata(SystemColors.ControlTextBrush));
            #endregion IconFill Property
            #region IsOpen Property
            public bool IsOpen
            {
                get { return (bool)GetValue(IsOpenProperty); }
                set { SetValue(IsOpenProperty, value); }
            }
            public static readonly DependencyProperty IsOpenProperty =
                DependencyProperty.Register("IsOpen", typeof(bool), typeof(IconPopupButton),
                    new PropertyMetadata(false));
            #endregion IsOpen Property
            #region StaysOpen Property
            public bool StaysOpen
            {
                get { return (bool)GetValue(StaysOpenProperty); }
                set { SetValue(StaysOpenProperty, value); }
            }
            public static readonly DependencyProperty StaysOpenProperty =
                DependencyProperty.Register("StaysOpen", typeof(bool), typeof(IconPopupButton),
                    new PropertyMetadata(false));
            #endregion StaysOpen Property
            #region Placement Property
            public PlacementMode Placement
            {
                get { return (PlacementMode)GetValue(PlacementProperty); }
                set { SetValue(PlacementProperty, value); }
            }
            public static readonly DependencyProperty PlacementProperty =
                DependencyProperty.Register("Placement", typeof(PlacementMode), typeof(IconPopupButton),
                    new PropertyMetadata(PlacementMode.Right));
            #endregion Placement Property
        }
    }
