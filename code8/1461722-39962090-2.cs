    using System;
    using System.Windows;
    using System.Windows.Controls;
    namespace HollowEarth.AttachedProperties
    {
        public static class PanelBehaviors
        {
            public static void UpdateChildFirstLastProperties(Panel panel)
            {
                for (int i = 0; i < panel.Children.Count; ++i)
                {
                    var child = panel.Children[i];
                    SetIsFirstChild(child, i == 0);
                    SetIsLastChild(child, i == panel.Children.Count - 1);
                }
            }
            #region PanelExtensions.IdentifyFirstAndLastChild Attached Property
            public static bool GetIdentifyFirstAndLastChild(Panel panel)
            {
                return (bool)panel.GetValue(IdentifyFirstAndLastChildProperty);
            }
            public static void SetIdentifyFirstAndLastChild(Panel panel, bool value)
            {
                panel.SetValue(IdentifyFirstAndLastChildProperty, value);
            }
            /// <summary>
            /// Behavior which causes the Panel to identify its first and last children with attached properties. 
            /// </summary>
            public static readonly DependencyProperty IdentifyFirstAndLastChildProperty =
                DependencyProperty.RegisterAttached("IdentifyFirstAndLastChild", typeof(bool), typeof(PanelBehaviors),
                    //  Default MUST be false, or else True won't be a change in 
                    //  the property value, so PropertyChanged callback won't be 
                    //  called, and nothing will happen. 
                    new PropertyMetadata(false, IdentifyFirstAndLastChild_PropertyChanged));
            private static void IdentifyFirstAndLastChild_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                Panel panel = (Panel)d;
                ((Panel)d).LayoutUpdated += (s, e2) => UpdateChildFirstLastProperties(panel);
            }
            #endregion PanelExtensions.IdentifyFirstAndLastChild Attached Property
            #region PanelExtensions.IsFirstChild Attached Property
            public static bool GetIsFirstChild(UIElement obj)
            {
                return (bool)obj.GetValue(IsFirstChildProperty);
            }
            public static void SetIsFirstChild(UIElement obj, bool value)
            {
                obj.SetValue(IsFirstChildProperty, value);
            }
            /// <summary>
            /// True if UIElement is first child of a Panel
            /// </summary>
            public static readonly DependencyProperty IsFirstChildProperty =
                DependencyProperty.RegisterAttached("IsFirstChild", typeof(bool), typeof(PanelBehaviors),
                    new PropertyMetadata(false));
            #endregion PanelExtensions.IsFirstChild Attached Property
            #region PanelExtensions.IsLastChild Attached Property
            public static bool GetIsLastChild(UIElement obj)
            {
                return (bool)obj.GetValue(IsLastChildProperty);
            }
            public static void SetIsLastChild(UIElement obj, bool value)
            {
                obj.SetValue(IsLastChildProperty, value);
            }
            /// <summary>
            /// True if UIElement is last child of a Panel
            /// </summary>
            public static readonly DependencyProperty IsLastChildProperty =
                DependencyProperty.RegisterAttached("IsLastChild", typeof(bool), typeof(PanelBehaviors),
                    new PropertyMetadata(false));
            #endregion PanelExtensions.IsLastChild Attached Property
        }
    }
