    public static T UpadateRowInModel<T>(DbContext Model, string NameiD, int IdSelected, string NameFk_key  ,int fk_key, IList<PropertyInfo> propertiesModel, IList<PropertyInfo> propertiesView, VMCaracteristicType vm) where T : class
    {
        T item = Model.Set<T>().Find(IdSelected);
        foreach (var property in propertiesModel)
        {
            if(property.Name == NameiD || property.Name == NameFk_key)
                continue;
            
            var viewP = propertiesView.FirstOrDefault(elem => elem.Name.Equals(property.Name));
            if (viewP != null)
            {
                property.SetValue(item, viewP.GetValue(vm));
            }            
        }
        return item;   
    }
