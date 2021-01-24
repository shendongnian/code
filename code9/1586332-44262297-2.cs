    public class MyDTO<T> : MyDTO {
        public MyDTO(MyDTO dto) {
            this.Id = dto.Id;
            this.Info = JsonConvert.DeserializeObject<T>(dto.Info);
        }
        public new T Info { get; set; }
    }
