    private static void TestReader()
        {
            var text = File.ReadAllText(@"D:\sample.txt");
            var fileLines = new List<SampleData>();
            foreach (var fileLine in text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                var lineData = fileLine.Split(',');
                
                // Make sure all the keys are present / do a separate check
                if (lineData.Length <= 2)
                {
                    continue;
                }
                fileLines.Add(new SampleData
                {
                    Code = Convert.ToString(lineData[0]),
                    Description = Convert.ToString(lineData[1]),
                    SelectedDate = lineData.Length >= 3 ? DateTime.ParseExact(lineData[2], "dd.MM.yyyy", null) : DateTime.MinValue
                });
            }
        }
        public class SampleData
        {
            public string Code { get; set; }
            public string Description { get; set; }
            public DateTime SelectedDate { get; set; }
        }
