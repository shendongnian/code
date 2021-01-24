    public partial class _Default : Page
    {
        private List<Equipment> equipments;
        protected void Page_Load(object sender, EventArgs e)
        {
            equipments = new List<Equipment>();
            var commandText = "SELECT EquipmentId, EquipmentName, CategoryId, SubCategoryId FROM Equipment";
            using (var connection = new SqlConnection("Data Source=.;Initial Catalog=LocalDevDb;User id=sa;Password=Password1"))
            {
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    using (var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var equipment = new Equipment
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                CategoryId = reader.GetString(2),
                                SubCategoryId = reader.GetString(3),
                            };
                            equipments.Add(equipment);
                        }
                    }
                }
            }
        }
    }
