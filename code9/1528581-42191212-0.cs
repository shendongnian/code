    private static readonly object _lock = new object();
    public void SetUploadResult(int partNumber, string etag)
    {
        if (etag == null)
        {
            throw new ArgumentNullException(nameof(etag));
        }
        ContributionPart part = this.Parts.SingleOrDefault(p => p.PartNumber == partNumber);
        if (part == null)
        {
            throw new ContributionPartNotFoundException(this.Id, partNumber);
        }
        part.SetUploadResult(etag);
        lock (_lock) //Only one thread at a time can enter this critical section.
                     //The second thread will wait here until the first thread leaves the critical section.
        {
            if (this.Parts.All(p => p.IsUploaded))
            {
                IEnumerable<PartUploadedResult> results = this.Parts.Select(p => new PartUploadedResult(p.PartNumber, p.ETag));
                this.Events.Add(new ContributionUploaded(this.Id, results));
            }
        }
    }
