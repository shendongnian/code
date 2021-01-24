    public static class PersonManager
    {
        private static MapperConfiguration _config;
        private static IMapper _mapper;
        public static void TestAutoMapper(DTO.Person p)
        {
            if (_config == null)
            {
                _config = new MapperConfiguration(cfg => cfg.AddProfile<MyCustomProfile>());
            }
            if (_mapper == null)
            {
                 _mapper = _config.CreateMapper();
            }
            using (MyDataSet dts = new MyDataSet())
            {
                XYdataset.PersonRow pr = _mapper.Map<XYdataset.PersonRow>(p, opt => opt.Items["Dataset"] = dts);
                dts.get_XYdataset().Person.AddPersonRow(pr);
            }
         }
     }
