            var param1 = new NpgsqlParameter("param1", NpgsqlDbType.Array | NpgsqlDbType.Bigint) { Value = Enumerable.Range(0, 10).ToArray()};
            
            var param2 = new NpgsqlParameter("param2", NpgsqlDbType.Bigint){ Value = 1}
            return DataSet
                .FromSql("select function_name(@param1, @param2) as \"SomeName\"", parameters: new object[] { param1, param2 })
                .FirstAsync();
        }
