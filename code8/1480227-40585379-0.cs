     //change class name and property names , You need to use coding conventions 
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    //this is a person repository interface
    public interface IPersonRepository
    {
        void Insert(People person);
        void Update(People person);
        void Delete(People person);
        People GetById(People person);
        IEnumerable<People> SelectAll();
    }
    //this class implement your interface
    class PersonRepository : IPersonRepository
    {
        private OracleConnection conn;
        //add constructor which create connection to DB
        public PersonRepository()
        {
            OracleConnectionStringBuilder sb = new OracleConnectionStringBuilder();
            sb.DataSource = "localhost";
            sb.UserID = "user";
            sb.Password = "password";
            conn = new OracleConnection(sb.ToString());
        }
        public void Delete(People person)
        {
            throw new NotImplementedException();
        }
        public People GetById(People person)
        {
            //Use try finally block to open and close connection
            try
            {
                conn.Open();
                //example select by id
                OracleDataAdapter sd = new OracleDataAdapter("SELECT * FROM PERSON WHERE PERSON.Id == " + person.Id,
                    conn);
            }
            finally
            {
                conn.Dispose();
            }
        }
        public void Insert(People person)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<People> SelectAll()
        {
            throw new NotImplementedException();
        }
        public void Update(People person)
        {
            throw new NotImplementedException();
        }
    }
