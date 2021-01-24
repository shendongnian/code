     DataTable schema = null;
            using (var schemaCommand = new MySqlCommand("SELECT * FROM " + firmCustomerTablename, connection))
            {
                using (var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly))
                {
                    schema = reader.GetSchemaTable();
                }
            }
