    string [] mathChemPhy = new string []
    {
        Constants.Classes.Math.ToString(),
        Constants.Classes.Chem.ToString(),
        Constants.Classes.Physics.ToString()
    };
    var itemsToRemove = subclasses.Classes.Where(x => mathChemPhy.Contains(x.Id)).ToList();
    subclasses.Classes.Remove(itemsToRemove); // overloaded version of Remove that takes a list
