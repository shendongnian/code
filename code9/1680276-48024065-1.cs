    public class MyCustomProfile : Profile
    {
        public MyCustomProfile()
        {
            CreateMap<DTO.Person, XYdataset.PersonRow>()  
                 .ConstructUsing((source, resolutionContext) =>  
                 (resolutionContext.Items["Dataset"] as MyDataSet)  
                 .(get_XYdataset().Person.NewPersonRow());
        }
    }
