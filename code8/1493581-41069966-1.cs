    public ImageSource MyImageSource
            {
                get
                { //here you decide what resource to use
                    return ImageSource.FromResource("(namespace).icon.png"); 
                }
            }
