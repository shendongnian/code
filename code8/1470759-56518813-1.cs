    namespace DAL.Models
    {
        public class PositionProfile : Profile
        {
            public PositionProfile()
            {
                CreateMap<Position, PositionDto_v1>();
            }
        }
        public class Position
        {
            ...
        }
