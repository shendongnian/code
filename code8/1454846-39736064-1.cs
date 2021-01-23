    public class MyJsonTest
    {
        public void TestNewJson()
        {
            var root = new JsonRoot()
            {
                Filename = "mypage.html",
                Id = "123",
                Title = "This is my page",
                Info = new Info()
                        {
                            description =
                                new Description()
                                {
                                    DateTimeValues = new object[] { DateTime.Now, DateTime.UtcNow },
                                    FieldType = 1,
                                    LinkedComponentValues = new object[] { "ABC", "XYZ" },
                                    Name = "MyInfo",
                                    NumericValues = new object[] { 1, 2, 3, 4, 5 },
                                    Values = (new List<string> { "some values" }).ToArray(),
                                },
                            title = new Title()
                                {
                                    FieldType = 5,
                                    NumericValues = new object[] { 1, 2, 43 },
                                    Values = new string[] { "sdfs", "dfgdf" },
                                    Name = "Some name",
                                    LinkedComponentValues = new object[] {"34555", "678786"},
                                    DateTimeValues = new object[] {DateTime.Now},
                                },
                        },
            };
            var json = JsonConvert.SerializeObject(root);
            Console.WriteLine(json);
        }
