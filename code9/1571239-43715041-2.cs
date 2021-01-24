         private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (Iteme)e.ClickedItem;
            switch (clickedItem.Category)
            {
                case ItemCategory.Type1:
                { 
                    //Do your works here
                    break;
                }
                
                case ItemCategory.Type2:
                { 
                    //Do your works here
                    break;
                }
            }
        }
