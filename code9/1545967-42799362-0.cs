    public class MyDataAccessClass {
        private IDbConnectionFactory connectionFactory;
        
        public MyDataAccessClass(IDbConnectionFactory connectionFactory) {
            this.connectionFactory = connectionFactory;
        }
    
        public void Insert(string firstname, string lastname) {
            var query = $"INSERT INTO `sakila`.`actor`(`first_name`,`last_name`) VALUES('" + firstname + "','" + lastname + "')";
            Console.WriteLine(query);
            using(var connection = connectionFactory.CreateConnection() {
                //Creates and returns a MySqlCommand object associated with the MySqlConnection. 
                using(var command = connection.CreateCommand()) {
                    command.CommandText = query;
                    Console.WriteLine("Established connection");
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Insert query succesfully executed.");
                    connection.Close();//is not actually necessary as the using statement will make sure to close the connection.
                }
            }
        }
    }
