    namespace Oficina.Dados
    {
        public class ClienteDados : DbHelper
        {
            //...
        }
    }
    namespace Oficina.Dados
    {
        public class DbHelper
        {
            public SqlCommand ExecutarProcedure(string procedure) { //... }
            public SqlCommand ExecutarProcedure(string procedure, List<SqlParameter> parametros) { //... }
        }
    }
