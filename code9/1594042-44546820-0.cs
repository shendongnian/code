        public ICollection<Bulletin> GetAll()
        {
            using (ISession session = null)
            {
                var bulletins = session
                    .CreateCriteria(typeof(Bulletin))
                    .CreateAlias("Recipient", "rec")
                    .SetProjection(Projections.ProjectionList()
                        .Add(Projections.Property("rec.Firstname"), "Firstname")
                    )
                    .AddOrder(Order.Asc("BulletinID"))
                    .AddOrder(Order.Asc("Firstname"))
                    .List<Bulletin>();
                return bulletins;
            }
        }
