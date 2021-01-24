    public static class LetterGrade
    {
        public static string ToLetterGrade(this double percentage)
        {
            var letterGrade = "F";
            if (percentage >= 0.9)
            {
                letterGrade = "A";
            }
            else if (percentage >= 0.8)
            {
                letterGrade = "B";
            }
            else if (percentage >= 0.7)
            {
                letterGrade = "C";
            }
            else if (percentage >= 0.6)
            {
                letterGrade = "D";
            }
            return letterGrade;
        }
    }
    //allows you to convert the CsvFile To a list to manipulate the data
            public static class CsvConverter
            {
                public static IEnumerable<Grade> ToList(string csvText)
                {
                    var gradeList = new List<Grade>();
                    var lines = csvText.Split("\n\r".ToCharArray());
                    foreach (var line in lines.Where(l=>!string.IsNullOrWhiteSpace(l)))
                    {
                        var lineArray = line.Split(',');
                        var score = 0;
                        var totalPoints = 0;
                        if(int.TryParse(lineArray[1],out score ) && int.TryParse(lineArray[2],out totalPoints))
                        {
                            var grade = new Grade(name: lineArray[0].Trim(), score: score, totalPoints: totalPoints);
                            gradeList.Add(grade);
                        }                 
                    }
                    return gradeList;
                }
            }
        public sealed class Grade
        {
            public Grade(string name, int score, int totalPoints)
            {
                Name = name;
                Score = score;
                TotalPoints = totalPoints;
            }
            public string Name { get;  }
            public int Score { get;  }
            public int TotalPoints { get; }
            public double Percentage() => Math.Round(Convert.ToDouble(Score) / Convert.ToDouble(TotalPoints),2);
            public string GetLetterGrade() => Percentage().ToLetterGrade();
        }
    //and the use:
            var csvString = File.ReadAllText(@"your path goes here");
            var currentGrades = CsvConverter.ToList(csvString);
            var totalGrade = new Grade("Total", score: currentGrades.Sum(grade => grade.Score), totalPoints: currentGrades.Sum(grade => grade.TotalPoints));
            var reportCard = currentGrades.ToList();
            reportCard.Add(totalGrade);
            var padding = 15;
            Console.Write("".PadRight(padding) + "Score".PadRight(padding) + "Total Points".PadRight(padding) + "Percentage".PadRight(padding) + "Letter Grade".PadRight(padding) + Environment.NewLine);
            foreach (var grade in reportCard)
            {
                Console.WriteLine(grade.Name.PadRight(padding) + grade.Score.ToString().PadRight(padding) + grade.TotalPoints.ToString().PadRight(padding) + grade.Percentage().ToString().PadRight(padding) + grade.GetLetterGrade().ToString().PadRight(padding) + Environment.NewLine);
            }
