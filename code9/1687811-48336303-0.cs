    class Paginated<T> {
        public int TotalPages {get; set;}
        public int CurrentPage {get; set;}
        public List<T> Data {get; set;}
    }
