            List<UpcPrintingProductModel> products = new List<UpcPrintingProductModel>();
            var sql = "select top 75 number, desc1, upccode "
                    + "from MailOrderManager..STOCK s "
                    + "where s.number like @puid + '%' "
            ;
            var connstring = ConfigurationManager.ConnectionStrings["MailOrderManagerContext"].ToString();
            using (var connection = new SqlConnection(connstring))
            using (var command = new SqlCommand(sql, connection)) {
                connection.Open();
                command.Parameters.AddWithValue("@puid", productNumber);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        var product = new UpcPrintingProductModel() {
                            ProductNumber = Convert.ToString(reader["number"]),
                            Description = Convert.ToString(reader["desc1"]),
                            Upc = Convert.ToString(reader["upccode"])
                        };
                        products.Add(product);
                    }
                }
            }
