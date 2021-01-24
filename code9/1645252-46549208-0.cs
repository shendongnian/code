    var TextFormat = "{0,-30} {1,-5} {2,-5} {3,-5} {4,-20}";
    Text += String.Format(TextFormat, "Name", "ID", "Rarity", "Attributes", "Tier");
    for(int i = 0; i < Items.Count; i++)
    {
        var Name = Items[i].Name;
        var ID = Items[i].Id;
        var Rarity = Items[i].Rarity;
        var Attributes = Items[i].Attributes.ToList();
        var Tier = Items[i].Tier;
        Text += String.Format(TextFormat, Name, ID, Rarity, Attributes[0], Tier);
        for(int i=1; i<Attributes.Count; i++){
            Text += String.Format(TextFormat, "", "", "", Attributes[i], "");
        }
    }
