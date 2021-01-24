    public class SetBlurEffectAction : TriggerAction<DependencyObject> {
        protected override void Invoke(object parameter) {
            var e = parameter as RoutedEventArgs;
            // OriginalSource is one of the buttons
            var parent = e?.OriginalSource as UIElement;
            // get Grid (parent of AdornerDecorator)
            while(true) {
                if(parent == null) {
                    return;
                }
                var grid = parent as Grid;
                if("Root_Grid".Equals(grid?.Name)) {
                    break;
                }
                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }
            // apply blur to this AdornerDecorator
            var deco = ((Grid)parent).GetElementByName("PART_WindowAdornerDecorator") as AdornerDecorator;
            if(deco == null) {
                return;
            }
            // != collapsed because the property is not updated yet
            if(StandardWindowEventHandler.LockedOverlayVisibility != Visibility.Collapsed) {
                deco.Effect = null;
            } else {
                deco.Effect = new BlurEffect {
                    KernelType = KernelType.Gaussian,
                    Radius = 7
                };
            }
        }
    }
