    void Main()
    {
        var experiences = Experiences.FilterBySelectedTags(new long[] { 2, 4 });
    
        experiences.Dump();
    }
    public static class ExperienceExtensions {
      public static IQueryable<Experience> FilterBySelectedTags(this IQueryable<Experience> experiences, IEnumerable<long> selectedTagIds)
      {
        return experiences.Where(e=>selectedTagIds.All(id=>e.Tags.Contains(id)));
      }
    }
