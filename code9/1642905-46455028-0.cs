            Mapper.CreateMap<ApplicationDriverFormVM, ApplicationDriverDomain>()
                .ForMember(dest => dest.Addresses, opt => opt.ResolveUsing(GetAddresses));
...
        static object GetAddresses(ApplicationDriverFormVM src)
        {
            var result = Mapper.Map<List<ApplicationDriverAddressDomain>>(src.PreviousAddresses);
            foreach(var item in result)
            {
                item.IsPresentAddress = false;
            }
            var present = Mapper.Map<ApplicationDriverAddressDomain>(src.PresentAddress);
            present.IsPresentAddress = true;
            result.Add(present);
            return result;
        }
