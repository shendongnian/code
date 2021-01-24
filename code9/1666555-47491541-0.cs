    public class Room : RealmObject
    {
        // Other properties
        // Notice that the collection may be private
        // to avoid polluting your public API
        [Backlink(nameof(Category.Rooms))]
        private IQueryable<Category> Categories { get; }
        // May also use FirstOrDefault if you can't guarantee
        // the room will be added to a single Category
        public Category Category => Categories.SingleOrDefault();
    }
