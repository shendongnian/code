    public static void ChangeInkAttributes_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                InkMenuItem inkmenuitem = sender as InkMenuItem;
    
                CommandParameter parameter = e.Parameter as CommandParameter;
    
                if (parameter != null)
                    parameter.CanEditBeExecuted = true;
    
                if (inkmenuitem != null)
                    inkmenuitem.changeInkAttributes();
    
                // this only causes a loop, it does not bubble.
                // inkmenuitem.RaiseEvent(e);
             
               
                InkMenuItem parent = inkmenuitem.Parent as InkMenuItem;
                if (parent != null)
                    parent.RaiseEvent(e);
            }
