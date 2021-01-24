    public int GetInscriptionIdByPersonId(int id)
        {
            using (var db = new HIQTrainingEntities())
            {
                var inscription =
                        from i in db.Inscriptions
                        join c in db.Certifications on i.PersonId equals c.PersonId
                        where i.PersonId == id
                        select new InscriptionDetail
                        {
                            Id = i.Id,
                        }; 
                return inscription.FirstOrDefault().Id;
                 }
        }
