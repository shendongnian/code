    namespace database
    {
    public class Program
    {
        static void Main(string[] args)
        {
            //WORKS!!
            var repro = new database.Data();
            var task1 = Task.Factory.StartNew(() => repro.GetData1(3));
            var task2 = Task.Factory.StartNew(() => repro.GetData2(5));
            var taskList = new List<Task> { task1, task2 };
            Task.WaitAll(taskList.ToArray());
            //FAILS WITH ERROR REPORTED!!
            repro = null;
            var task1 = Task.Factory.StartNew(() => repro.GetData1(3));
            var task2 = Task.Factory.StartNew(() => repro.GetData2(5));
            var taskList = new List<Task> { task1, task2 };
            Task.WaitAll(taskList.ToArray());
        }
    }
    class Data
    {
        private string connectionString = "Server=.;Database=CRUD_Sample;Integrated Security=True;Asynchronous Processing = True;";
        public DataTable GetData1(int Id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Get_CustomerbyID", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@id", Value = Id });
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    
        public DataTable GetData2(int Id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Get_CustomerbyID", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@id", Value = Id });
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
    }
