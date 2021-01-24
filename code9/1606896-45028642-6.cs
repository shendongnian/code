    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public IEnumerable<Genre> GetSelfAndAncestors(IEnumerable<Genre> items)
        {
            yield return this;
            if (ParentId.HasValue)
            {
                var parent = items.First(x => x.Id == ParentId.Value);
                foreach (var ancestor in parent.GetSelfAndAncestors(items))
                {
                    yield return ancestor;
                }
            }
        }
    }
