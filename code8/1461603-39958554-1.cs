    /// <summary>
    /// All my recangles
    /// </summary>
    private ObservableCollection<MyRectangleViewModel> AllMyRecangles = new ObservableCollection<MyRectangleViewModel>();
    /// <summary>
    /// Call this method if you add/remove objects to your list.
    /// </summary>
    public void RefreshObjects()
    {
        this.myCanvas.Children.Clear();
        foreach (MyRectangleViewModel item in AllMyRecangles)
        {
            Rectangle newRectangle = new Rectangle();
            //set the DataContext
            newRectangle.DataContext = item;
            //create the binding
            Binding b = new Binding();
            b.Source = item;
            b.Path =new PropertyPath(nameof(Background));
            b.Mode = BindingMode.TwoWay;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //setup the binding XAML: <Rectangle Fill = {Binding Path="Background", Mode=TwoWay, UpdateSourceTrigger ="PropertyChanged" />
            BindingOperations.SetBinding(newRectangle, Rectangle.FillProperty, b);
            //add the rectangle to the canvas
            myCanvas.Children.Add(newRectangle);
        }
    }
