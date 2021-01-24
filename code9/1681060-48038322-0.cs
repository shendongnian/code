    class PersonMapperProfile : AutoMapper.Profile
    {
        public PersonMapperProfile()
        {
            this.CreateMap<Student, StudentEntity>();
            this.CreateMap<Worker, WorkerEntity>();
            this.CreateMap<Person, PersonEntity>()
                .Include<Student, StudentEntity>()
                .Include<Worker, WorkerEntity>();
        }
    }
