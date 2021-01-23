    using System.Windows;
    using System.Windows.Controls;
    namespace HollowEarth.Behaviors
    {
        public static class PanelBehaviors
        {
            public static void UpdateChildIndexProperties(Panel panel)
            {
                for (int i = 0; i < panel.Children.Count; ++i)
                {
                    var child = panel.Children[i];
                    SetChildIndex(child, i);
                }
            }
            #region PanelBehaviors.IsChildPositionIndicated Attached Property
            public static bool GetIsChildPositionIndicated(Panel panel)
            {
                return (bool)panel.GetValue(IsChildPositionIndicatedProperty);
            }
            public static void SetIsChildPositionIndicated(Panel panel, bool value)
            {
                panel.SetValue(IsChildPositionIndicatedProperty, value);
            }
            /// <summary>
            /// Behavior which causes the Panel to identify its first and last children with attached properties. 
            /// </summary>
            public static readonly DependencyProperty IsChildPositionIndicatedProperty =
                DependencyProperty.RegisterAttached("IsChildPositionIndicated", typeof(bool), typeof(PanelBehaviors),
                    new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsArrange, IsChildPositionIndicated_PropertyChanged));
            private static void IsChildPositionIndicated_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                Panel panel = (Panel)d;
                ((Panel)d).LayoutUpdated += (s, e2) => UpdateChildIndexProperties(panel);
            }
            #endregion PanelBehaviors.IsChildPositionIndicated Attached Property
            #region PanelBehaviors.ChildIndex Attached Property
            public static int GetChildIndex(UIElement obj)
            {
                return (int)obj.GetValue(ChildIndexProperty);
            }
            public static void SetChildIndex(UIElement obj, int value)
            {
                obj.SetValue(ChildIndexProperty, value);
            }
            public static readonly DependencyProperty ChildIndexProperty =
                DependencyProperty.RegisterAttached("ChildIndex", typeof(int), typeof(PanelBehaviors),
                    new FrameworkPropertyMetadata(-1,
                        FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsParentArrange));
            #endregion PanelBehaviors.ChildIndex Attached Property
        }
    }
