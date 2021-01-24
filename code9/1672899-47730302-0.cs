    public class Tags
    {
        private readonly IEnumerable<Tag> contextTags;
        private readonly string rawTags;
        public Tags(string tags, IEnumerable<Tag> contextTags)
        {
            this.rawTags = tags ?? string.Empty;
            this.contextTags = contextTags;
        }
        public IEnumerable<Tag> ToList()
        {
            List<Tag> tags = new List<Tag>();
            string[] tagNames = this.rawTags.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string tagName in tagNames)
            {
                tags.Add(this.GetTag(tagName));
            }
            return tags;
        }
        private Tag GetTag(string tagName)
        {
            return this.contextTags.FirstOrDefault(x => x.Name == tagName) ?? new Tag { Name = tagName };
        }
    }
