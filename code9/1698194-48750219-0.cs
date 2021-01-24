    interface IEntity
    {
       int Id {get;set;}
    }
    
    class Student : IEntity
    {
       int Id {get;set;}
       string SubjectOpted {get;set;}
    }
    
    class Employee : IEntity
    {
       int Id {get;set;}
       string DepartmentName{get;set;}
    }
    
    interface INonGenericRepository
    {
       IEntity Get(int id)
    }
    
    interface IGenericRepository<T>
    {
       T Get(int id)
    }
    
    class NonGenericRepository : IRepository
    {
       public IEntity Get(int id) {/*implementation goes here */
    }
    
    class GenericRepository<T> : IRepository<T>
    {
       public T Get(int id) {/*implementation goes here */
    }
    
    Class NonGenericStudentConsumer
    {
       IEntity student = new NonGenericFRepository().Get(5);
       var Id = student.Id
       var subject = student.SubjectOpted /*does not work, you need to cast */
    }
    
    Class GenericStudentConsumer
    {
       var student = new GenericFRepository<Student>().Get(5);
       var Id = student.Id
       var subject = student.SubjectOpted /*works perfect and clean */
    }
