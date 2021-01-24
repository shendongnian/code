    using Dapper;
    using System.Data.SqlClient;
    using System.Linq;
    
    public class Students
    {
        private string name;
        private string age;
        private string adress;
    
        public Students(string name, string age, string adress)
        {
            this.name = name;
            this.age = age;
            this.adress = adress;
        }
        public override string ToString() => $"{name}, {age}, {adress}";
    }
    static class P
    {
        static void Main()
        {
            using (var connection = new SqlConnection("Data Source=.;Initial Catalog=master;Integrated Security=SSPI;"))
            {
                const string myQuery = "select 'fred' as [name], '27' as [age], 'somewhere' as [adress]";
                var studentsInfo = connection.Query<Students>(myQuery).ToList();
                foreach(var student in studentsInfo)
                {
                    System.Console.WriteLine(student);
                }
            }
        }
    }
