            var mapper = new MapperConfiguration(expression =>
            {
                expression.CreateMap<Customer, CustomerDto>()
                    .ForMember(dto => dto.Id, obj => obj.MapFrom(customer => customer.Id))
                    .ReverseMap();
                expression.CreateMap<Address, AddressDto>()
                    .ForMember(dto => dto.Id, obj => obj.MapFrom(address => address.Id))
                    .ForMember(dto => dto.CustomerId, obj => obj.MapFrom(address => address.Customer.Id))
                    .ReverseMap();
                expression.CreateMap<Order, OrderDto>()
                    .ForMember(dto => dto.Id, obj => obj.MapFrom(order => order.Id))
                    .ForMember(dto => dto.AddressId, obj => obj.MapFrom(order => order.Address.Id))
                    .ForMember(dto => dto.CustomerId, obj => obj.MapFrom(order => order.Customer.Id))
                    .ReverseMap();
            }).CreateMapper();
