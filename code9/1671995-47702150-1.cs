    class Program
    {
        class Object1 {
            public int Object1Id;
            public List<Object2> Object2s;
        }
        class Object2 {
            public int Object2Id;
            public List<Object3> Object3s;
        }
        class Object3 {
            public int Object3Id;
        }
        static void Main(string[] args)
        {
            using(var conn = new SqlConnection("Data Source=localhost; Initial Catalog=tempdb; Integrated Security=SSPI"))
            {
                var json = conn.ExecuteScalar<string>(@"               
                    SELECT 
                        *
                    FROM 
                        [Object1] 
                    LEFT JOIN
                        [Object2] AS Object2s ON [Object1].Object1Id = [Object2s].Object1Id
                    LEFT JOIN 
                        [Object3] AS Object3s ON [Object2s].Object2Id = [Object3s].Object2Id
                    WHERE
                        [Object1].Object1Id = 1
                    FOR
                        JSON AUTO,WITHOUT_ARRAY_WRAPPER
                ");                                
                var result = JsonConvert.DeserializeObject<Object1>(json.Replace("\"", "'"));
                Console.WriteLine(result.Object2s.Count);
            }
        }
    }
