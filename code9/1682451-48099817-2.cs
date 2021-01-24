    int count = VisualTreeHelper.GetChildrenCount(myControl);
    for (int i = 0; i < count; i++)
    {
       DependencyObject current = VisualTreeHelper.GetChild(myControl, i);
       
       // lets say you have to transverse over a Grid
       if (current.GetType().Equals(typeof(Grid)))
       {
           int count2 = VisualTreeHelper.GetChildrenCount(current);
           for(int k=0; k < count2 ; k++)
           {
              DepedencyObject currentX = VisualTreeHelper.GetChild(current, k)
              
              .....
              // Keeping transversing the Tree
              .....
              if(currentX.GetType().Equals(typeof(Border))
              {
                 Border border = (Border)currentX;
                 Border.Background = .... 
              }
           }
       }
    }
