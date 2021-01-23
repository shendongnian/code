     private void MapGender()
        {
           List<Gender> MappedGender = new List<Contracts.Data.Gender>();
           IList<GenderEntity> genderEntity = _GenderServiceObject.GenderEntity();
            if(genderEntity!=null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<GenderEntity, Gender>();
                });
                IMapper mapper = config.CreateMapper();
                gender = mapper.Map<IList<GenderEntity>, IList<Gender>>(genderEntity).ToList();
            }
                      
        }
