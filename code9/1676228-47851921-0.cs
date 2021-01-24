     public class DropdownList<TParent,TChild> where TParent : class
    {
        public List<SelectListItem> ListItems;
        public DropdownList(int id, string navigationProperty)
        {
            ListItems = new List<SelectListItem>();
            DatabaseEntities db = new DatabaseEntities();
            TParent parentEntity = db.Set<TParent>().Find(id);
            DbEntityEntry<TParent> parentEntityEntry = db.Entry(parentEntity);
            DbCollectionEntry<TParent,TChild> navigationPropertyCollection = parentEntityEntry.Collection(navigationProperty).Cast<TParent, TChild>();
            ListItems.Add(new SelectListItem { Value = "-1", Selected = false, Text = "Select " + navigationProperty });
            foreach (dynamic entity in navigationPropertyCollection.CurrentValue)
            {
                ListItems.Add(new SelectListItem
                {
                    Value = Convert.ToString(entity.Id),
                    Text = entity.Name,
                    Selected = false
                });
            }
        }
    }
