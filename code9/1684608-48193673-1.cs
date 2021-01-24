    public static Customer ToEntity(this CustomerEditViewModel model, Customer destination)
    {
        return Mapper.CreateMap<CustomerEditViewModel, Customer>()
                     .ForMember(dest => dest.Email, opt => opt.Ignore()
                     .ForMember(dest => dest.Phone, opt => opt.Ignore()
                    );
    } 
  
