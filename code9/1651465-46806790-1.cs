    public static class ControlExtension
    {
      public static IEnumerable<Control> GetControls<Control>(this IEnumerable<Control> parent,
            Func<Control, IEnumerable<Control>> childrenSelector)
       {              
            foreach (Control item in parent)
            {
              // Yield parent items
              yield return item;
    
              // Yield all of the children.
              foreach (Control child in childrenSelector(item).GetControls(childrenSelector))
              {                  
                  yield return child;
              }
            }
       }
    }
