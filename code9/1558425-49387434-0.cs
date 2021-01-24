    using (NpgsqlBinaryExporter reader = conn.BeginBinaryExport("COPY tableName(colONE, colTWO) TO STDOUT (FORMAT BINARY)"))
            {
                while(reader.StartRow() > 0)
                {
                    Console.WriteLine(reader.Read<string>());
                    Console.WriteLine(reader.Read<int>(NpgsqlDbType.Smallint));
                }
            }
