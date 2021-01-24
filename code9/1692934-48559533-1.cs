    void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
    	...
        else if(e.PropertyName == "WidthRatio")
        {
            widthRatio = ((MyMasterDetailPage)Element).WidthRatio;
        }
    }
