    int r =0;
    int g =0;
    int b =0;
    //Marshalls back to UI thread
    Dispatcher.Invoke(()=>{
     r = ((Color)ShapeColor.GetValue(SolidColorBrush.ColorProperty)).R;
     g = ((Color)ShapeColor.GetValue(SolidColorBrush.ColorProperty)).G;
     b = ((Color)ShapeColor.GetValue(SolidColorBrush.ColorProperty)).B;
    });
    //Creates object on BGW thread and can be safely used for serialization
    return Color.FromRgb(r, g, b);
