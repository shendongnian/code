    using (dbPMEntities db = new dbPMEntities())
    {
    var model = db.staffCompetence;
    
    foreach (Guid id in ids)
    {
        **var scs = model.FirstOrDefault(s => s.competenceID.HasValue?s.competenceID.CompareTo(id):null);   //Do double-check to see whether the competenceID is of a real value……and check firstOrDefault()**
    
        if (scs==null)
        {
            var item = new staffCompetence();
            item.recID = Guid.NewGuid();
            item.competenceID = id;
            model.Add(item);
        }
     }
    }
