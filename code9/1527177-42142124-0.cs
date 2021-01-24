        public Contatti GetContatto([FromUri]int id)
        {
            using(var db = new WebEntities())
            {
                return(db.Contatti.Single(x => x.IDContatto == id));
            }
        }
