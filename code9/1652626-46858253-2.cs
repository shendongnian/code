    using System;
    class Program
    {
        //defining a blacklist of unwanted terms that should not appear in your column names or value strings
        //This is just for the sake of the example, and there are definitely some statements missing in this array
        static string[] QUERY_BLACKLIST = { "SELECT", "DROP", "INSERT", "DELETE", "UPDATE" };
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
        //example for the blacklist check
        query = "INSERT INTO table (:columns:) VALUES (:values:);";
        //strings with malicious intent behind them
        string[] columns2 =  { "DROP table" };
        string[] values2 = { "DELETE * FROM table" };
        try
        {
            query = Program.FillColumnsIntoQuery(query, columns2, values2);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            //Output:
            //"Someone is trying to do evil stuff!"
        }
        Console.ReadLine();
        }
        public static string FillColumnsAndValuesIntoInsertQuery(string query, string[] colums, string[] values)
        {
        //joining the string arrays with a comma character
        string columnnames = string.Join(",", colums);
        //adding values with single quotation marks around them to handle errors related to string values
        string valuenames = "'" + string.Join("','", values) + "'"; ; 
        //we need to check every entry of the blacklist against the provided strings
        foreach(string blacklist in QUERY_BLACKLIST)
        {
            if(columnnames.ToLower().IndexOf(blacklist.ToLower()) >= 0
            || valuenames.ToLower().IndexOf(blacklist.ToLower()) >=0)
            {
                throw new Exception("Someone is trying to do evil stuff!");
            }
        }
        //replacing the markers with the desired column names and values
        return query.Replace(":columns:",columnnames).Replace(":values:", valuenames);
        }
    }
