        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var itemType = item.GetType();
            var isGroup = itemType.Name == "GroupInfoList";
            bool isEmpty = false;
            GroupInfoList groupItem;
            if (isGroup)
            {
                groupItem = item as GroupInfoList;
                isEmpty = groupItem.Count == 0;
                // Disable empty items
                var selectorItem = container as SelectorItem;
                if (selectorItem != null)
                {
                    selectorItem.IsEnabled = !isEmpty;
                }
                if (isEmpty)
                {
                    return Empty;
                }
                else
                {
                    return Full;
                }
            }
            return Full;
        }
