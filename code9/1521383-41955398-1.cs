    class Articolo {
        public int ID { get; set; }
        public List<Tag> ArticoloTag { get; set; }
        public string Title { get; set; }
    }
    class Tag {
        public int ID { get; set; }
        public string TagText { get; set; }
    }
