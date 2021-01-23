    var entity = ConvertGameDtoToEntity(gettingDto);
    public SampleEntity ConvertGameDtoToEntity(SampleDto gettingDto)
    {
            return new SampleEntity 
            {
                Id = gettingDto.Id,
                Name= gettingDto.Name,
                Address = gettingDto.Address,
            };
    }
