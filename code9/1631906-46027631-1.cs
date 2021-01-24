      public static void EmployeeReflection(List<Employee> EmpList)
        {
            PropertyInfo[] pInfo = typeof(Employee).GetProperties();
            //or
            //  PropertyInfo[] pinfo = EmpList.GetType().GetProperties();
            foreach (Employee emp in EmpList)
            {
                for (int i= 0; i < pInfo.Length; i++)
                {
                    string name = pInfo[i].Name;
                    object value = pInfo[i].GetValue(emp);
                    Console.WriteLine("property name: " + name);
                    Console.WriteLine("property value: " + value);
                    Console.WriteLine("..........");
                }
            }
                     
        }
