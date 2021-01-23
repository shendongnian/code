	// Allocate a new RootObject
    var newRoot = new RootObject();
	// Add listeners to process chunks of Person objects as they are added
    newRoot.People.CollectionChanged += (o, e) =>
        {
			// Process each chunk of 5000.
            var collection = (ICollection<Person>)o;
            ProcessItems(collection, false);
        };
    newRoot.OnDeserialized += (o, e) =>
        {
			// Forcibly process any remaining no matter how many.
            ProcessItems(((RootObject)o).People, true);
        };
	// Deserialize from the stream onto the pre-allocated newRoot
    Serializer.Merge(stream, newRoot);
