        public void InlineQueryWrite(Dictionary<Int32, PhaseMag> data)
        {
            using (var conn = new SqlConnection("conneciton string"))
            {
                conn.Open();
                foreach (var bulk in data.Select((d, i) => new {d, i}).GroupBy(x => x.i % 10))
                {
                    var sb = new StringBuilder();
                    foreach (var x in bulk)
                    {
                        sb.AppendFormat("Insert Into Your_Table (Key, Magnitude, Phase) Values ({0},{1},{2});", x.d.Key, x.d.Value.Magnitude, x.d.Value.Phase);
                    }
                    using (var command = conn.CreateCommand())
                    {
                        command.CommandText = sb.ToString();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
