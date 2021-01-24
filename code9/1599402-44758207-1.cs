    public class DataService
    {
        public DataService()
        {
            MyMapper.Initialize();
        }
        public List<Dto.StudentDto> GetStudent(int id)
        {
            using (var context = new DbContext().GetContext())
            {
                var student = context.Students.FirstOrDefault(x => x.Id == id)
                var returnDto = Mapper.Map<List<Dto.StudentDto>>(student);
                return returnDto;
            }
        }
    }
