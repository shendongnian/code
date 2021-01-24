     //Declare a scroll viewer object.
     ScrollViewer  sViewer = default(ScrollViewer );
    
     //Start looping the child controls of your listview.
     for (int i = 0; i < VisualTreeHelper.GetChildrenCount(YOUR_LISTVIEW_OBJECT.VisualParent ); i++)
     {
            // Retrieve child visual at specified index value.
            Visual childVisual = (Visual)VisualTreeHelper.GetChild(YOUR_LISTVIEW_OBJECT.VisualParent , i);
    
            ScrollViewer sViewer = childVisual as ScrollViewer;
    
    	    //You got your scroll viewer. Stop looping.
    	     if (sViewer != null)
             {
                 break;
             }      
     }
