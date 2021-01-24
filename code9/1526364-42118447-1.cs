        public static void AddStandardStudentMap(this IMappingExpression<Student, StudentViewModel> map)
        {
            map.ForMember(dest => dest.OtherName, opt => opt.MapFrom(src => src.OtherProperty))
               .ForMember(dest => dest.OtherName2, opt => opt.MapFrom(src => src.OtherProperty2));
            // you can concat .ForMember() for each property you need.
        }
