    string htmlDescription = "<ul>";
    foreach (Entity presName in entCol.Entities)
    {
      //Get Opty ID and Name
      htmlDescription += string.Format("<li>{0} || {1}</li>",  presName.Id, presName.GetAttributeValue<string>("name"));
    }
    
    htmlDescription += "</ul>";
