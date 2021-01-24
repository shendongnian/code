        public void TestMethod()
        {
            List<Course> CourseList = new List<Course>();
            Enumerable.Range(0, 5).ToList().ForEach(i =>
            {
                Enumerable.Range(0, 3).ToList().ForEach(j =>
                {
                    var fake = Isolate.Fake.NextInstance<Course>();
                    Isolate.WhenCalled(() => fake.CourseMethod()).DoInstead(c =>
                    {
                        Console.WriteLine(string.Format("Faked = {0}", fake.Grade));
                    });
                    CourseList.Add(fake);
                }
                );
                new Student().StudentTestMethod();
            });
        }
