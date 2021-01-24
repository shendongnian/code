    <Canvas x:Name="grdMain" Loaded="grdMain_Loaded">...
----------
    private void grdMain_Loaded(object sender, RoutedEventArgs e)
    {
        Canvas canvas = sender as Canvas;
        ScaleTransform st = new ScaleTransform();
        BindingOperations.SetBinding(st, ScaleTransform.ScaleXProperty, new Binding("ScaleFactor"));
        BindingOperations.SetBinding(st, ScaleTransform.ScaleYProperty, new Binding("ScaleFactor"));
        st.CenterX = canvas.ActualWidth / 2;
        st.CenterY = canvas.ActualHeight / 2;
        canvas.LayoutTransform = st;
    }
