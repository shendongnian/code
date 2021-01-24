    while (reader.Read())
        {
          for (int i=0; i < reader.FieldCount; i++)
          {
            Console.Write(reader[i] + ",");
          }
          Console.WriteLine();
        }
