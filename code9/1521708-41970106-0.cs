    HashSet<Weapon> Weapons;
    Weapons = new HashSet<Weapon>();
    Weapons.Add(new Weapon()); // Assume this is created and populated elsewhere
    StringBuilder SBText = new StringBuilder(64 + (Weapons.Count * 8)); // An approximation of the eventual string length
    SBText.Append(@"Class, Level, etc...");
    // Cryptic but compact Lync method (Not my favourite)
    Weapons.Where(Wpn => !string.IsNullOrEmpty(Wpn.name)).ToList().ForEach(delegate (Weapon Wpn) { if (SBText.Length > 0) { SBText.Append(@", "); } SBText.Append(Wpn.name); });
    // Explicit code method
    foreach (Weapon Wpn in Weapons)
    {
        if (!string.IsNullOrEmpty(Wpn.name))
        {
            if (SBText.Length > 0) { SBText.Append(@", "); }
            SBText.Append(Wpn.name);
        }
    }
    Console.WriteLine(SBText.ToString());
