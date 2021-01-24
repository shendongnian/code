    class TemplateSelector : DataTemplateSelector {
        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            FrameworkElement element = container as FrameworkElement;
            if(element != null && item != null && item is string) {
                string phase = (string)item;
                if(phase == "Purchase Parts") {
                    return element.FindResource("PurchasePartsTemplate") as DataTemplate;
                }else if(phase == "Piece Parts") {
                    return element.FindResource("PiecePartsTemplate") as DataTemplate;
                }
            }
            return null;
        }
    }
