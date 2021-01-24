    public class GroupEventualityDto<T>
    {
        public int Id { get; set; }
        public int IdGroup { get; set; }
        public int IdEventuality { get; set; }
        public T Value { get; set; }
    }
