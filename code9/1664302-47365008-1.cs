    public class Student
    {
        int id;
        string name;
        string address;
    }
    
    public void updateStudent(Student st)
    {
        var student = _cache.Get(CacheVariable.cache_data_student) as List<Student>;
        //First look for the st in Student list, you need the id field or primary key
        var s = student.Where(x => x.idField == st.idField).FirstOrDefault();
        s = st;
        //student = st;//student.Update(st); //Not working. Only pass the value
    }
