    using System;
    using System.ComponentModel;
    using System.Windows;
    namespace HollowEarth.Behaviors
    {
        public static class Validation
        {
            #region Validation.OnPropertyChanged Attached Property
            public static DependencyProperty GetOnPropertyChanged(FrameworkElement obj)
            {
                return (DependencyProperty)obj.GetValue(OnPropertyChangedProperty);
            }
            public static void SetOnPropertyChanged(FrameworkElement obj, DependencyProperty value)
            {
                obj.SetValue(OnPropertyChangedProperty, value);
            }
            public static readonly DependencyProperty OnPropertyChangedProperty =
                DependencyProperty.RegisterAttached("OnPropertyChanged", typeof(DependencyProperty), typeof(Validation),
                    new PropertyMetadata(null, OnPropertyChanged_PropertyChanged));
            private static void OnPropertyChanged_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var obj = d as FrameworkElement;
                if (e.OldValue != null)
                {
                    DependencyPropertyDescriptor.
                        FromProperty(e.OldValue as DependencyProperty, obj.GetType())
                        .RemoveValueChanged(obj, ValidateHandler);
                }
                if (e.NewValue != null)
                {
                    DependencyPropertyDescriptor.
                        FromProperty(e.NewValue as DependencyProperty, obj.GetType())
                        .AddValueChanged(obj, ValidateHandler);
                }
            }
            static void ValidateHandler(object sender, EventArgs args)
            {
                var fe = (FrameworkElement)sender;
                var dprop = GetOnPropertyChanged(fe);
                fe.GetBindingExpression(dprop).ValidateWithoutUpdate();
            }
            #endregion Validation.OnPropertyChanged Attached Property
        }
    }
