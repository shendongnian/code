    class CommonClass : Canvas
    {
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            //some behavior
        }
        //other common implementation for derived classes
    }
    
    class A : CommonClass 
    {
        // implementation specific to "A" and overrides
    }
    
    class B : CommonClass 
    {
        // implementation specific to "B" and overrides
    }
