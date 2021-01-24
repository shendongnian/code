    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    namespace SwitchTestProject
    {
        [ContentProperty("Items")]
        public class Switch : Control
        {
            public Switch()
            {
                Items = new List<DependencyObject>();
            }
            static Switch()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(Switch), new FrameworkPropertyMetadata(typeof(Switch)));
            }
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
                OnValueChanged(null);
            }
            #region Switch.When Attached Property
            public static Object GetWhen(DependencyObject obj)
            {
                return (Object)obj.GetValue(WhenProperty);
            }
            public static void SetWhen(DependencyObject obj, Object value)
            {
                obj.SetValue(WhenProperty, value);
            }
            public static readonly DependencyProperty WhenProperty =
                DependencyProperty.RegisterAttached("When", typeof(Object), typeof(Switch),
                    new PropertyMetadata(null));
            #endregion Switch.When Attached Property
            #region Content Property
            public Object Content
            {
                get { return (Object)GetValue(ContentProperty); }
                protected set { SetValue(ContentPropertyKey, value); }
            }
            internal static readonly DependencyPropertyKey ContentPropertyKey =
                DependencyProperty.RegisterReadOnly(nameof(Content), typeof(Object), typeof(Switch),
                    new PropertyMetadata(null));
            public static readonly DependencyProperty ContentProperty = ContentPropertyKey.DependencyProperty;
            #endregion Content Property
            #region Value Property
            public Object Value
            {
                get { return (Object)GetValue(ValueProperty); }
                set { SetValue(ValueProperty, value); }
            }
            public static readonly DependencyProperty ValueProperty =
                DependencyProperty.Register(nameof(Value), typeof(Object), typeof(Switch),
                    new FrameworkPropertyMetadata(null, Value_PropertyChanged));
            protected static void Value_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                (d as Switch).OnValueChanged(e.OldValue);
            }
            private void OnValueChanged(object oldValue)
            {
                //  XXX I can't make this work properly with enums (seriously), 
                //  so I'm comparing them as strings just so I can test the content-
                //  switching code. 
                //
                //  I presume you've solved the enum comparison problem. 
                Content = Items.FirstOrDefault(item => $"{GetWhen(item)}" == $"{Value}");
            }
            #endregion Value Property
            #region Items Property
            public List<DependencyObject> Items
            {
                get { return (List<DependencyObject>)GetValue(ItemsProperty); }
                protected set { SetValue(ItemsPropertyKey, value); }
            }
            internal static readonly DependencyPropertyKey ItemsPropertyKey =
                DependencyProperty.RegisterReadOnly(nameof(Items), typeof(List<DependencyObject>), typeof(Switch),
                    new PropertyMetadata(null));
            public static readonly DependencyProperty ItemsProperty = ItemsPropertyKey.DependencyProperty;
            #endregion Items Property
        }
    }
