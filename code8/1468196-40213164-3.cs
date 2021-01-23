     private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
     {
         if (depObj != null)
         {
             for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
             {
                 DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                 if (child != null && child is T)
                 {
                     yield return (T)child;
                 }
                 foreach (T childOfChild in FindVisualChildren<T>(child))
                 {
                     yield return childOfChild;
                 }
             }
         }
     }
     private void Page_Loaded(object sender, RoutedEventArgs e)
     {
         IEnumerable<PivotHeaderPanel> headerpanel = FindVisualChildren<PivotHeaderPanel>(CustomPivot);
         double totalwidth = headerpanel.ElementAt<PivotHeaderPanel>(0).ActualWidth;
         IEnumerable<PivotHeaderItem> items = FindVisualChildren<PivotHeaderItem>(CustomPivot);
         int headitemcount = items.Count();
         for (int i = 0; i < headitemcount; i++)
         {
             items.ElementAt<PivotHeaderItem>(i).Width = totalwidth / headitemcount;
         }
     }
