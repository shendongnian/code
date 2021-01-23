     public class MultiSelectorExtensions
        {
            public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.RegisterAttached(
                "SelectedItems",
                typeof(INotifyCollectionChanged),
                typeof(MultiSelectorExtensions),
                new PropertyMetadata(default(INotifyCollectionChanged), OnSelectedItemsChanged));
    
            private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                MultiSelector multiSelectorControl = d as MultiSelector;
    
                NotifyCollectionChangedEventHandler handler = (sender, args) =>
                {
                    if (multiSelectorControl != null)
                    {
                        IList listSelectedItems = multiSelectorControl.SelectedItems;
                        if (args.OldItems != null)
                        {
                            foreach (var item in args.OldItems)
                            {
                                if (listSelectedItems.Contains(item))
                                    listSelectedItems.Remove(item);
                            }
                        }
    
                        if (args.NewItems != null)
                        {
                            foreach (var item in args.NewItems)
                            {
                                if (!listSelectedItems.Contains(item))
                                    listSelectedItems.Add(item);
                            }
                        }
                    }
                };
    
                if (e.OldValue == null && multiSelectorControl != null)
                {
                    multiSelectorControl.SelectionChanged += OnSelectionChanged;
                }
    
                if (e.OldValue is INotifyCollectionChanged)
                {
                    (e.OldValue as INotifyCollectionChanged).CollectionChanged -= handler;
                }
    
                if (e.NewValue is INotifyCollectionChanged)
                {
                    (e.NewValue as INotifyCollectionChanged).CollectionChanged += handler;
                }
    
            }
    
            private static void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                DependencyObject d = sender as DependencyObject;
    
                if (GetSelectionChangedInProgress(d))
                    return;
    
                SetSelectionChangedInProgress(d, true);
    
                dynamic selectedItems = GetSelectedItems(d);
    
                try
                {
                    foreach (dynamic item in e.RemovedItems.Cast<dynamic>().Where(item => selectedItems.Contains(item)))
                    {
                        selectedItems.Remove(item);
                    }
                }
                catch (Exception) { }
    
                try
                {
                    foreach (dynamic item in e.AddedItems.Cast<dynamic>().Where(item => !selectedItems.Contains(item)))
                    {
                        selectedItems.Add(item);
                    }
                }
                catch (Exception){}
    
                SetSelectionChangedInProgress(d, false);
            }
    
            public static void SetSelectedItems(DependencyObject element, INotifyCollectionChanged value)
            {
                element.SetValue(SelectedItemsProperty, value);
            }
    
            public static INotifyCollectionChanged GetSelectedItems(DependencyObject element)
            {
                return (INotifyCollectionChanged)element.GetValue(SelectedItemsProperty);
            }
    
            private static readonly DependencyProperty SelectionChangedInProgressProperty = DependencyProperty.RegisterAttached(
                "SelectionChangedInProgress",
                typeof(bool),
                typeof(MultiSelectorExtensions),
                new PropertyMetadata(default(bool)));
    
            private static void SetSelectionChangedInProgress(DependencyObject element, bool value)
            {
                element.SetValue(SelectionChangedInProgressProperty, value);
            }
    
            private static bool GetSelectionChangedInProgress(DependencyObject element)
            {
                return (bool)element.GetValue(SelectionChangedInProgressProperty);
            }
        }
