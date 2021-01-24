    for (int i = autoListe.Count - 1; i >= 0; i--)
    {
        var a = autoListe[i];
    
        if (a.X > 550 || a.X < -50 || a.Y > 550 || a.Y < -50)
        {
          autoListe.RemoveAt(i);
        }
    }
