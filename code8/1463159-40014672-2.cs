            var connection = new SqlConnection("Your_connection_string");
            var parameters = new SqlParameter[]
            {
                new SqlParameter("ClassName", "Robotics"),       //example of string value
                new SqlParameter("IsActive", true)               //example of numeric value
            };
            var dataSet = GetDataSet(connection, "usp_getStudentsAndClasses", parameters);
            var firstTable = dataSet?.Tables?[0];   //use as any other data table...
