    Mapper.CreateMap<Source, Destination>()
           .ForMember(x => x.Resources , y => y.MapFrom(z => getAssignees(z.Assignees)));
     private  List<int> getAssignees(string model)
            {
               
                if (string.IsNullOrEmpty(model))
                {
                    return null;
                }
    
                return model.Split(',').Cast<int>().ToList();
    
            }
