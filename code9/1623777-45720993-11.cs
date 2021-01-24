    var res = Enum.GetNames(typeof(Fruits))
        .Where(x => x != "Default");
    List<SelectListItem> list = new List<SelectListItem>();
    foreach (string fruit in res)
    {
        string desc = EnumHelper<Fruits>.GetEnumDescription(fruit); // This is a utility method I use. You can get the description using your extension method.
        int val = (int)Enum.Parse(typeof(Fruits), fruit);
        list.Add(new SelectListItem { enumName = fruit, enumDesc = desc, enumVal = val });
    }
