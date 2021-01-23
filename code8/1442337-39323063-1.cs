    class DatabaseUploadActions : IUploadActions
    {
        public bool Commit<T>(UploadInformation information)
           where T : class, IUploadEntity
        {
            var uploads = GetStoredUploads(information.UniqueId);
            var entity = db.Set<T>().Include(e => e.Uploads)
                 .Single(e => e.UniqueId == information.UniqueId);
            entity.Uploads.AddRange(uploads);
            ...
        }
    }
