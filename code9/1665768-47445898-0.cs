    List<Sight> sightsToPull = SightCol.Find(x => evnt.RelatedSightsId.Contains(x.Id)).ToList();
    foreach (Sight e in sightsToPull)
    {
         foreach (var x in e.RelatedEventsId)
         {
            if (x == evnt.Id)
            {
                 e.RelatedEventsId.Remove(x);
                 break;
                        }
            }
         SightCol.ReplaceOne(x => x.Id == e.Id, e);
    }
