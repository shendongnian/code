    MyObject x = new MyObject(...);
    //..........
    var propInfo = x.GetType().GetProperty("something");
    if (propInfo != null) {
        MyPropertyType xyz = (MyPropertyType)propInfo.GetValue(x,null);
        if(xyz != null) {
            double width = xyz.Metrics.Width;
        }
    }
