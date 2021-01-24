    public HomeController(Prog_II_ModelRepository modelRepository)...
    public class Prog_II_ModelRepository()
    {
       IGenericRepository<Student> _genericRepository_Student; // get from somewhere
       public Prog_II_Model GetModel()
       {
           var model = new Prog_II_Model();
           model.Student = _genericRepository_Student.Get(); // some student
           // put the rest of data into your huge all-encompassing model
           return model;
       }
    }
