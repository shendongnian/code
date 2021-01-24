    UpdateListContent(_allGroups[SelectedIndex], SelectedIndex);
    private void UpdateListContent(MenuItemGroup group, int index)
    {
     if(group.Expanded)
     {
      foreach (var menuItem in group)
       {
         ExpandedGroup.Insert(index++, menuItem);
       }
     }
     else
     {
      foreach (var menuItem in group)
       {
         ExpandedGroup.Remove(menuItem); //Can also use ExpandedGroup.RemoveAt(index++);   
       }
      }
    }
