    /// <summary>
    /// Represents a list of documents.
    /// </summary>
    public class Documents
    {
        /// <summary>
        /// Initialises the private list of documents.
        /// </summary>
        public Documents()
        {
            _docs = new List<Document>();
        }
        /// <summary>
        /// Add a speified document.
        /// </summary>
        /// <param name="doc">This document will be added to the saved documents.</param>
        public void Add(Document doc)
        {
            _docs.Add(doc);
        }
        /// <summary>
        /// Remove a specific document.
        /// </summary>
        /// <param name="doc">This document will be removed from the saved documents.</param>
        public void Remove(Document doc)
        {
            _docs.Remove(doc);
        }
        /// <summary>
        /// Removes all saved documents.
        /// </summary>
        public void Clear()
        {
            _docs.Clear();
        }
        /// <summary>
        /// "Casts" this instance to a list of documents.
        /// </summary>
        /// <returns>Returns all documents inside a list.</returns>
        public List<Document> ToList() => _docs;
        /// <summary>
        /// A list of documents.
        /// </summary>
        private readonly List<Document> _docs;
    }
