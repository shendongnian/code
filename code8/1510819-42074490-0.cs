    using AutoMapper;
    using System;
    using System.Linq;
    namespace ConsoleApplicationAutoMapper
    {
        class Program
        {
            static void Main(string[] args)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDto>()
                                                            .ForMember(dest => dest.DtoMyProperty, x => x.MapFrom(y => y.MyProperty)
                                                              ));
                Order order = new Order() { MyProperty = 12 };
                var typeMaps = config.CreateMapper()
                                     .ConfigurationProvider
                                     .GetAllTypeMaps()
                                     .Where(t => t.SourceType == typeof(Order) && t.DestinationType == typeof(OrderDto))
                                     .Single()
                                     .GetPropertyMaps();
                foreach (var map in typeMaps)
                    Console.WriteLine(map.SourceMember.Name + "->" + map.DestinationProperty.Name);
            
                Console.ReadLine();
            }
        }
        public class Order
        {
            public int MyProperty { get; set; }
        }
        public class OrderDto
        {
            public int DtoMyProperty { get; set; }
        }
    }
