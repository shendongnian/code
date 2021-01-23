    public interface IAmDTO {
        int Id { get; set; }
        string Name { get; set; }
    }
    public class DTO1 : IAmDTO {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DTO2 : IAmDTO {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DTO1Service {
        public static List<DTO1> GetListOfDTO1() =>
            new List<DTO1>
            {
            new DTO1 { Id = 1, Name = "DTO 1" },
            new DTO1 { Id = 2, Name = "DTO 2" },
            };
    }
    public class DTO2Service {
        public static List<DTO2> GetListOfDTO2() =>
            new List<DTO2>
            {
            new DTO2 { Id = 1, Name = "DTO 1" },
            new DTO2 { Id = 2, Name = "DTO 2" },
            };
    }
    }
    public static class DTOExtensions {
    public static void DtoHelper(this IEnumerable<IAmDTO> dtoS) {
        foreach(var dto in dtoS) {
            //DO SOMETHING WITH
            var id = dto.Id;
            var name = dto.Name;
        }
    }
}
