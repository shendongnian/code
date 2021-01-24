            var ids = new int[] { 1, 95, 46, 93, 98, 77 };
            bool isFirst = true;
            StringBuilder commandBuilder = new StringBuilder("SELECT * FROM EmailsAddress WHERE Id IN (");
            var command = new SqlCommand("");
            for (var i = 0;i<ids.Length;i++)
            {
                if (!isFirst) commandBuilder.Append(",");
                else isFirst = false;
                var paramName = "@ID" + i;
                commandBuilder.Append(paramName);
                command.Parameters.AddWithValue(paramName, ids[i]);
            }
            commandBuilder.Append(")");
            command.CommandText = commandBuilder.ToString();
            command.ExecuteReader();
            // Read your result
