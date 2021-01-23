    private void InitializeObjectListView()
    {
        //Other settings for ObjectListView
        this.ObjectLV.RowHeight = 40;
        this.ObjectLV.EmptyListMsg = "No item found";
       
        //Set Image index for Button Column
        this.olvButton.ImageGetter = delegate(object x)
        {
            //ImageList is a control in which I have added one Image.
            return imagesList.Images[0];
        };
    }
