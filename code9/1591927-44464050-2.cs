    foreach (var item in ListaPersonas.ToList())
    {
        if (item.GetType().GetProperty("Nombre") != null &&
            item.GetType().GetProperty("Nombre").PropertyType.Equals(typeof(string)) && 
            item.Nombre == "jose")
        {
            ListaPersonas.Remove(item);
            ListaPersonas.Add(new { valor = 7, Nombre = item.Nombre });
        }
    }
