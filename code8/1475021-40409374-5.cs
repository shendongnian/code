    class Poll
    {
        [JsonConverter(typeof(CollectionConverter<AnswersCollection, Answer>), "answers")]
        public AnswersCollection answers { get; set; }
        [JsonConverter(typeof(CollectionConverter<TagsCollection, Tag>), "tags")]
        public TagsCollection tags { get; set; }
        public string question { get; set; }
    }
