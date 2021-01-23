     public static class Extensions {
        public static T GetDescendantByType<T>(this Visual element) where T : class {
          if (element == null) {
            return default(T);
          }
          if (element.GetType() == typeof(T)) {
            return element as T;
          }
          T foundElement = null;
          if (element is FrameworkElement) {
            (element as FrameworkElement).ApplyTemplate();
          }
          for (var i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++) {
            var visual = VisualTreeHelper.GetChild(element, i) as Visual;
            foundElement = visual.GetDescendantByType<T>();
            if (foundElement != null) {
              break;
            }
          }
          return foundElement;
        }
    
        public static void BringItemIntoView(this ItemsControl itemsControl, object item) {
          var generator = itemsControl.ItemContainerGenerator;
    
          if (!TryBringContainerIntoView(generator, item)) {
            EventHandler handler = null;
            handler = (sender, e) =>
            {
              switch (generator.Status) {
                case GeneratorStatus.ContainersGenerated:
                  TryBringContainerIntoView(generator, item);
                  break;
                case GeneratorStatus.Error:
                  generator.StatusChanged -= handler;
                  break;
                case GeneratorStatus.GeneratingContainers:
                  return;
                case GeneratorStatus.NotStarted:
                  return;
                default:
                  break;
              }
            };
    
            generator.StatusChanged += handler;
          }
        }
    
        private static bool TryBringContainerIntoView(ItemContainerGenerator generator, object item) {
          var container = generator.ContainerFromItem(item) as FrameworkElement;
          if (container != null) {
            container.BringIntoView();
            return true;
          }
          return false;
        }
    
      }
