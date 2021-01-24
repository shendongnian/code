    public Employee GetEmployee(int Key)
    {
          //Employee employee = new Employee();//this will make the condition always true
          Employee employee = null;//Replace it with this to start with null value
          if (con.State != System.Data.ConnectionState.Open)
          {
              con.Open();
          }
