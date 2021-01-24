      public static void EmployeeReflection(List<Employee> EmpList)
        {
            PropertyInfo[] pInfo = typeof(Employee).GetProperties();
            //or
            //  PropertyInfo[] pinfo = EmpList.GetType().GetProperties();
            for (int i= 0; i < EmpList.Count; i++)
                {
                    string name = pInfo[i].Name;
                    object value = pInfo[i].GetValue(EmpList[i]);
                    Console.WriteLine("property name: " + name);
                    Console.WriteLine("property value: " + value);
                    Console.WriteLine("..........");
                }
                /* or using foreach
             int count = 0;
            foreach (Employee emp in EmpList)
            {
                string name = pInfo[count].Name;
                object value = pInfo[count].GetValue(emp);
                Console.WriteLine("property name: " + name);
                Console.WriteLine("property value: " + value);
                Console.WriteLine("..........");
                count++;
            }
            */
                     
        }
