    this.obj2 = (global::Windows.UI.Xaml.Controls.Grid)target;
    (this.obj2).RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Canvas.LeftProperty,
        (global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop) =>
        {
            if (this.initialized)
            {
                // Update Two Way binding
                this.dataRoot.PositionX = global::Windows.UI.Xaml.Controls.Canvas.GetLeft(this.obj2);
            }
        });
    (this.obj2).RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.Canvas.TopProperty,
        (global::Windows.UI.Xaml.DependencyObject sender, global::Windows.UI.Xaml.DependencyProperty prop) =>
        {
            if (this.initialized)
            {
                // Update Two Way binding
                this.dataRoot.PositionY = global::Windows.UI.Xaml.Controls.Canvas.GetTop(this.obj2);
            }
        }); 
