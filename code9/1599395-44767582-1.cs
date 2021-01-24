    public class StudentDocs 
    {
    
        //some code over here
    
        string sResult = ProcessDocs().Result;
    
        //If string sResult is not empty there was an error
        if (!sResult.Equals(string.Empty))
            throw new Exception(sResult);
    
        //some code over there
    
        
        ##region Methods   
        
        public async Task<string> ProcessDocs() 
        {
            string sResult = string.Empty;
    
            try
            {
                var taskStuDocs = GetStudentDocumentsAsync(item.NroCliente);
                var taskStuClasses = GetStudentSemesterClassesAsync(item.NroCliente, vencimientoParaProductos);
    
                //We Wait for BOTH TASKS to be accomplished...
                await Task.WhenAll(taskStuDocs, taskStuClasses);
    
                //Get the IList<Class>
                var docsStudent = taskStuDocs.Result;
                var docsCourses = taskStuClasses.Result;
                
               /*
                    You can do something with this data ... here
                */
            }
            catch (Exception ex)
            {
                sResult = ex.Message;
                Loggerdb.LogInfo("ERROR:" + ex.Message);
            }
        }
    
        public async Task<IList<classA>> GetStudentDocumentsAsync(long studentId)
        {
            return await Task.Run(() => GetStudentDocuments(studentId)).ConfigureAwait(false);
        }
    
        public async Task<IList<classB>> GetStudentSemesterCoursessAsync(long studentId)
        {
            return await Task.Run(() => GetStudentSemesterCourses(studentId)).ConfigureAwait(false);
        }
    
        //Performs task to bring Student Documents
        public IList<ClassA> GetStudentDocuments(long studentId)
        {
            IList<ClassA> studentDocs = new List<ClassA>();
    
            //Let's execute a Stored Procedured map on Entity Framework
            using (ctxUniversityData oQuery = new ctxUniversityData())
            {
                //Since both TASKS are running at the same time we use AsParallel for performing parallels LINQ queries
                foreach (var item in oQuery.GetStudentGrades(Convert.ToDecimal(studentId)).AsParallel())
                {
                    //These are every element of IList
                    studentDocs.Add(new ClassA(
                        (int)(item.studentId ?? 0),
                            item.studentName,
                            item.studentLastName,
                            Convert.ToInt64(item.studentAge),
                            item.studentProfile,
                            item.studentRecord
                        ));
                }
            }
            return studentDocs;
        }
    
        //Performs task to bring Student Courses per Semester
        public IList<ClassB> GetStudentSemesterCourses(long studentId)
        {
            IList<ClassB> studentCourses = new List<ClassB>();
    
            //Let's execute a Stored Procedured map on Entity Framework
            using (ctxUniversityData oQuery = new ctxUniversityData())
            {
                //Since both TASKS are running at the same time we use AsParallel for performing parallels LINQ queries
                foreach (var item in oQuery.GetStudentCourses(Convert.ToDecimal(studentId)).AsParallel())
                {
                    //These are every element of IList
                    studentCourses.Add(new ClassB(
                        (int)(item.studentId ?? 0),
                            item.studentName,
                            item.studentLastName,
                            item.carreerName,
                            item.semesterNumber,
                            Convert.ToInt64(item.Year),
                            item.course ,
                            item.professorName
                        ));
                }
            }
            return studentCourses;
        }
    
        #endregion
    }
