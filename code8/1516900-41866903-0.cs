            static void Main(string[] args)
             {
                var url = "http://localhost:64743/";
                var client = new HttpClient();
                client.BaseAddress = new Uri(url);
                 //Post    
                  var students = new List<StudentList>
                  {
                     new StudentList { researchid="1234", studentid="5689",
                      courses = new List<Course>
                        {
                        new Course { courseName="os", professorName="donchi lee"           },
                          new Course { courseName="database", professorName="jie,joe" }
                               },
                                          exams=new List<Exam> { }
                                     }
                                    };
                               var response = client.PostAsJsonAsync("api/Student", students).ConfigureAwait(false).Result;
                            if (response.IsSuccessStatusCode)
                                  {
                                   Console.WriteLine(response.StatusCode);
                                       }
                                          }
