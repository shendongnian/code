    namespace Foo.Behaviors
    {
        using System.Linq;
        using Xamarin.Forms;
        /// <summary>
        ///     Identifies the first and last child of a <see cref="Layout{View}"/>.
        /// </summary>
        public class FirstAndLastChildBehavior
        {
            /// <summary>
            ///     Identifies the first and last child of the given <see cref="Layout{View}"/>.
            /// </summary>
            /// <param name="layout">The <see cref="Layout{View}"/>.</param>
            public static void UpdateChildFirstLastProperties(Layout<View> layout)
            {
                // This is just here to provide a convenient place to do filtering, e.g. .Where(v => v.IsVisible).
                var children = layout.Children;
                for (var i = 0; i < children.Length; ++i)
                {
                    var child = children[i];
                    SetIsFirstChild(child, i == 0);
                    SetIsLastChild(child, i == children.Length - 1);
                }
            }
            #region PanelExtensions.IdentifyFirstAndLastChild Attached Property
            /// <summary>
            ///     Gets a value that controls whether the child-identifying functionality is enabled for the given <see cref="Layout{View}"/>.
            /// </summary>
            /// <param name="layout">The <see cref="Layout{View}"/>.</param>
            /// <returns><c>True</c> if functionality has been enabled, <c>false</c> otherwise.</returns>
            public static bool GetIdentifyFirstAndLastChild(Layout<View> layout)
            {
                return (bool)layout.GetValue(IdentifyFirstAndLastChildProperty);
            }
            /// <summary>
            ///     Sets a value that controls whether the child-identifying functionality is enabled for the given <see cref="Layout{View}"/>.
            /// </summary>
            /// <param name="layout">The <see cref="Layout{View}"/>.</param>
            /// <param name="value">The value.</param>
            public static void SetIdentifyFirstAndLastChild(Layout<View> layout, bool value)
            {
                layout.SetValue(IdentifyFirstAndLastChildProperty, value);
            }
            /// <summary>
            ///     Identifies the <see cref="IdentifyFirstAndLastChild"/> property.
            /// </summary>
            /// <remarks>
            ///     The behavior can't be turned off; once the value is set to <c>true</c> the behavior will stick even if it's set back to
            ///     <c>false</c> later.
            /// </remarks>
            public static readonly BindableProperty IdentifyFirstAndLastChildProperty = BindableProperty.CreateAttached(
                "IdentifyFirstAndLastChild",
                typeof(bool),
                typeof(FirstAndLastChildBehavior),
                false,
                BindingMode.OneWay,
                null,
                IdentifyFirstAndLastChildPropertyChanged);
            /// <summary>
            ///     Gets called when IdentifyFirstAndLastChildProperty changes.
            /// </summary>
            /// <param name="bindable">The object we're bound to.</param>
            /// <param name="oldValue">This parameter is not used.</param>
            /// <param name="newValue">This parameter is not used.</param>
            private static void IdentifyFirstAndLastChildPropertyChanged(BindableObject bindable, object oldValue, object newValue)
            {
                var layout = (Layout<View>)bindable;
                ((Layout<View>)bindable).LayoutChanged += (a, b) => UpdateChildFirstLastProperties(layout);
            }
            #endregion PanelExtensions.IdentifyFirstAndLastChild Attached Property
            #region PanelExtensions.IsFirstChild Attached Property
            /// <summary>
            ///     Gets a value that determines whether the given <see cref="View"/> is the first child of its parent.
            /// </summary>
            /// <param name="obj">The <see cref="View"/>.</param>
            /// <returns><c>True</c> if the <see cref="View"/> is the first child, <c>false</c> otherwise.</returns>
            public static bool GetIsFirstChild(View obj)
            {
                return (bool)obj.GetValue(IsFirstChildProperty);
            }
            /// <summary>
            ///     Sets a value that determines whether the given <see cref="View"/> is the first child of its parent.
            /// </summary>
            /// <param name="obj">The <see cref="View"/>.</param>
            /// <param name="value">The value.</param>
            public static void SetIsFirstChild(View obj, bool value)
            {
                obj.SetValue(IsFirstChildProperty, value);
            }
            /// <summary>
            ///     Identifies the <see cref="IsFirstChild"/> property.
            /// </summary>
            public static readonly BindableProperty IsFirstChildProperty = BindableProperty.CreateAttached(
                "IsFirstChild",
                typeof(bool),
                typeof(FirstAndLastChildBehavior),
                false);
            #endregion PanelExtensions.IsFirstChild Attached Property
            #region PanelExtensions.IsLastChild Attached Property
            /// <summary>
            ///     Gets a value that determines whether the given <see cref="View"/> is the last child of its parent.
            /// </summary>
            /// <param name="obj">The <see cref="View"/>.</param>
            /// <returns><c>True</c> if the <see cref="View"/> is the last child, <c>false</c> otherwise.</returns>
            public static bool GetIsLastChild(View obj)
            {
                return (bool)obj.GetValue(IsLastChildProperty);
            }
            /// <summary>
            ///     Sets a value that determines whether the given <see cref="View"/> is the last child of its parent.
            /// </summary>
            /// <param name="obj">The <see cref="View"/>.</param>
            /// <param name="value">The value.</param>
            public static void SetIsLastChild(View obj, bool value)
            {
                obj.SetValue(IsLastChildProperty, value);
            }
            /// <summary>
            ///     Identifies the <see cref="IsLastChild"/> property.
            /// </summary>
            public static readonly BindableProperty IsLastChildProperty = BindableProperty.CreateAttached(
                "IsLastChild",
                typeof(bool),
                typeof(FirstAndLastChildBehavior),
                false);
            #endregion PanelExtensions.IsLastChild Attached Property
        }
    }
