    public class SubDTO
    {
        public int Id { get; set; }
        public string Label { get; set; }
    }
    public class DTO
    {
        public int SubDtoId
        {
            get
            {
                return SubDTO.Id;
            }
        }
        public string SubDtoLabel
        {
            get
            {
                return SubDto.Label;
            }
        }
        public string Caract { get; set; }
        public string Serial { get; set; }
        public string Comment { get; set; }
        public SubDTO SubDTO { get; set; }
    }
