    using Newtonsoft.Json;
    public void GetEmpleadoJSON()
        {
            string server = "localhost", database = "ventas", user = "root", pass = "";
            MySqlConnection conectar = new MySqlConnection("server=" + server + "; database=" + database + "; Uid=" + user + "; pwd=" + pass + ";");
            conectar.Open();
            MySqlCommand command = conectar.CreateCommand();
            //consulta select
            command.CommandText = ("SELECT `nombre` FROM `cliente` WHERE id_cliente=901 ");
            command.Connection = conectar;
            MySqlDataReader reader = command.ExecuteReader();
            Empleado[] emps = new Empleado[] {
        new Empleado(){
            Id=101,
            Name=reader.ToString(),
            Salary=10000
        }
    };
            var jsonString = JsonConvert.SerializeObject(emps);
            Context.Response.Write(jsonString);
        }
