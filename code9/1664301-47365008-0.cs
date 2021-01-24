    public class Student
    {
        int id;
        string name;
        string address;
    }
    
    public void updateStudent(Student st)
    {
        var student = _cache.Get(CacheVariable.cache_data_student) as List<Student>;
        student = st;//student.Update(st); //Not working. Only pass the value
    }
