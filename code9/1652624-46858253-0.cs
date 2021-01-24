    using System;
    class Program
    {
        static void Main(string[] args)
        {
        //Use markers in your query string
        string query = "INSERT INTO table (:columns:) VALUES (:values:);";
        //define an array of column names to insert for the :columns: marker
        string[] columns = { "ID", "Name", "Age", "Something"};
        //some dummy values. Real code would use a model or something to that effect
        int id = 9;
        string name = "John";
        int age = 12;
        bool something = true;
        //all values should be passed as strings, they will replace the :values: marker
        string[] values = { id.ToString(), name, age.ToString(), something.ToString()};
        query = Program.FillColumnsIntoQuery(query, columns, values);
        Console.WriteLine(query);
        //Output:
        //"INSERT INTO table (ID,Name,Age,Something) VALUES ('9','John','12','true');"
        Console.ReadLine();
        }
        public static string FillColumnsAndValuesIntoInsertQuery(string query, string[] colums, string[] values)
        {
        //joining the string arrays with a comma character
        string columnnames = string.Join(",", colums);
        //adding values with single quotation marks around them to handle errors related to string values
        string valuenames = "'" + string.Join("','", values) + "'"; ; 
        //replacing the markers with the desired column names and values
        return query.Replace(":columns:",columnnames).Replace(":values:", valuenames);
        }
    }
