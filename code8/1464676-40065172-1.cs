    public static List<SelectListItem> ToMultipleSelectListItems<T>(this List<T> items, Func<T, string> nameSelector, Func<T, Guid> valueSelector, List<Guid> selected, Func<T, string> orderBy)
    {
      return items.OrderBy(orderBy).Select(item =>
          new SelectListItem
          {
              Text = nameSelector(item),
              Value = valueSelector(item).ToString(),
              Selected = selected.Contains(valueSelector(item))
          }).ToList());
    }
    model.Abilities = (await Api.GetAbilities()).ToMultipleSelectListItems(
        x => x.Name, 
        x => x.Id, 
        model.Task.SelectedAbilitiesList, 
        x => x.OrderBy.ToString()
    );
