    using DTO;
    using Model;
    // we might use AutoMapper instead
    public static class PersonConverter
    {
        public static Person ToModel(this PersonDTO dto)
        {
            Person result = new Person
            {
                Id = dto.Id,
                Name = dto.Name,
                Age = dto.Age
            };
            return result;
        }
    }
