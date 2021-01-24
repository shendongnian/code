    var autosDieGeloeschtWerdenSollen = new List<Auto>();
    foreach (Auto a in autoListe)
    {
        if (a.X > 550 || a.X < -50 || a.Y > 550 || a.Y < -50)
        {
            autosDieGeloeschtWerdenSollen.Add(a);
        }
    }
    autoListe.RemoveRange(autosDieGeloeschtWerdenSollen );
