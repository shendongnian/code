    public class ShortCutUtils
    {
	  public static void ImplementShortCut(ContentControl page)
	  {
		 List<Button> ListButton = new List<Button>();
	  	 ListButton = FindVisualChildren<Button>(page).ToList();
	      ...
	  }
     private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
     {
     if (depObj != null)
      {
        int NbChild = VisualTreeHelper.GetChildrenCount(depObj);
        for (int i = 0; i < NbChild; i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
            if (child != null && child is T)
            {
                yield return (T)child;
            }
            foreach (T childNiv2 in FindVisualChildren<T>(child))
            {
                yield return childNiv2;
            }
        }
      }
     }
    }
