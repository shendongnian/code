    [assembly: ExportRenderer(typeof(MasterDetailPage), typeof(CustomMasterDetailPageRender))]
    public class CustomMasterDetailPageRender : MasterDetailPageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<MasterDetailPage> e)
        {
            base.OnElementChanged(e);
            if (Element != null)
            {                
                Element.Appearing += Element_Appearing;                         
            }
        }
        private void Element_Appearing(object sender, EventArgs e)
        {
            (sender as MasterDetailPage).Appearing -= Element_Appearing;
            if (Control != null)
            {
                var topBarArea = FindElementByName(Control, "TopCommandBarArea");
                if (topBarArea != null)
                {
                    var topContent = FindElementByType<StackPanel>(topBarArea);
                    if (topContent != null)
                    {
                        topContent.Background = new SolidColorBrush(Colors.Green);
                    }
                }          
            }
        }
        static DependencyObject FindElementByName(DependencyObject parent, string name)
        {            
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var sub = VisualTreeHelper.GetChild(parent, i);
                if (sub is FrameworkElement)
                {
                    if (((FrameworkElement)sub).Name == name)
                    {
                        return sub;
                    }
                }
                
                var r = FindElementByName(sub, name);
                if (r != null)
                    return r;
            }
            return null;
        }
        static T FindElementByType<T>(DependencyObject parent)
            where T: DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var sub = VisualTreeHelper.GetChild(parent, i);
                if (sub is T)
                {
                    return (T)sub;
                }
                var r = FindElementByType<T>(sub);
                if (r != null)
                    return r;
            }
            return null;
        }
    }
