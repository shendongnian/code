    foreach (Variety variety in varieties.ToList())
    {
        if (variety.Type != main.Type && variety.Type != null)
        {
             varieties.Remove(variety);
        }
    }
