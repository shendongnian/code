    public List<Course> Model
    {
        get
        {
            List<Course> courses = new List<Course>();
            // Some example data, in your situation you should instantiate the classes based on the data from the database.
            Course exampleCourse = new Course();
            exampleCourse.ID = 1;
            exampleCourse.Name = "Example course";
            
            // Create example module 1
            Module exampleModule1 = new Module();
            exampleModule1.ID = 10;
            exampleModule1.Name = "Example Module 1";
            // Create example module 2
            Module exampleModule2 = new Module();
            exampleModule2.ID = 11;
            exampleModule2.Name = "Example Module 2";
            // add modules to the course
            exampleCourse.Modules.Add(exampleModule1);
            exampleCourse.Modules.Add(exampleModule2);
            // add course to the courses
            courses.Add(exampleCourse);
            return courses;
        }
    }
