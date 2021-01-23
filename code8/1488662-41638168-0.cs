    public Candidate GetArtifact(int artifactId)
    {
        using (var context = new DataEntities())
        {
            return context.Artifacts.AsNoTracking()
                .Where(x => x.ArtifactId == artifactId)
                .FirstOrDefault();
        }
    }
