    public class MyDTO<T> {
        public MyDTO(MyDTO dto) {
            this.Id = Id;
            this.Info = JsonConvert.DeserializeObject<T>(dto.Info);
        }
        public int Id { get; set; }
        public T Info { get; set; }
    }
