    public async Task<DTOs.EmployeeDTO> GetEmployeeInfo(int userId)
            {
               
                    EmployeeDTO employee = new EmployeeDTO();
    
                    Task<EmployeeDTO> task = Task.Factory.StartNew(() =>
                    {
                        Parallel.Invoke(
                         () => { employee.Languages = GetEmployeeLanguages(userId).Result; },
                         () => { employee.Educations = GetEmployeesEducation(userId).Result; },
                         () => { employee.OutExperiences = GetEmployeesOutExperience(userId).Result; },
                         () => { employee.UbiExperiences = GetEmployeesUbiExperience(userId).Result; });
    
                        return employee;
                    });
                    task.Wait();
                    
                return task.Result;
                
            }
