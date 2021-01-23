	var archetypes = new List<Tuple<int, ArchetypesLokaal>>();
    //Iterate over all the archetypes
    foreach(var archetype in db.ArchetypesLokaals)
    {
        //Get all the facilities that are present in archetype
        var temp = GetFaciliteitenVoorArchetype(archetype);
        //Create a new list to add all the facilities that are matched
        var temp2 = new List<FaciliteitenLokaalFixed>();
        //Iterate over the facilities provided as a parameter, these are the facilities that have to be present in the archetype
        foreach(var faciliteit in faciliteiten)
        {
            //CHeck if facility is present in an archetype
            var aanwezig = temp.FirstOrDefault(t => t.Naam.Equals(faciliteit.Naam));
            if (aanwezig!=null)
            {
                //Add if it's present
                temp2.Add(faciliteit);
            }
        }
        var needed = faciliteiten.Count;
        var present = temp2.Count;
        //Compare how many facilities were met
        if (present / needed >= .5)
        {
            archetypes.Add(new Tuple<int, ArchetypesLokaal>(present, archetype));
        }
    }
    return archetypes.OrderBy(q => q.Item1).Select(q => q.Item2).ToList();
