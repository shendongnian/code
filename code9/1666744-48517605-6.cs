        public override IServiceResult<IList<Datei>> LoadAllData()
        {
            using (var db = this.DomainContextFactory.Create())
            {
                var files = db.Datei
                    .ToListAsync<Datei>();
                return new ServiceResult<IList<Datei>>(files.Result, files.Result.Count);
            }
        }
