    foreach (var p in propertiesView)
    {
        foreach (var property in propertiesModel)
        {
            property.SetValue(item, p.GetValue(property.Name)); // erreur L’objet ne correspond pas au type cible, ou une propriété est une propriété d’instance mais obj a la valeur null.
        }
    }
