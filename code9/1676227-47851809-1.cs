    /* Change Constraints on Type Parameters to allow only IDropdownOption */
    public class DropdownList<TParentEntity, TChildEntity> where TParentEntity : EntityObject where TChildEntity : EntityObject, IDropdownOption
    {
    
    public List<SelectListItem> ListItems;
    public DropdownList(int parentId)
    {
        DatabaseEntities db = new DatabaseEntities();
        TParentEntity parentEntity = db.Set<TParentEntity>().Find(parentId);
        DbEntityEntry parentEntityEntry = db.Entry(parentEntity);
        ListItems.Add(new SelectListItem { Value = "-1", Selected = false, Text = "Select " + typeof(TChildEntity).Name });
        /* assuming you can load child entities as list then you just convert it like below */
    ListItems.AddRange(childrenEntities.OfType<IDropdownOption>().Select(s => new SelectItem
    {
    Text = s.Text, Value = s.Value
    }));
    }
    }
