    foreach (var item in ListaPersonas.ToList())
    {
        if (item.GetType().GetProperty("Nombre") != null &&
            item.Nombre == "jose")
        {
            ListaPersonas.Remove(item);
            ListaPersonas.Add(new { valor = 7, Nombre = item.Nombre });
        }
    }
