        [TestMethod]
        public void TestGroupingAndOrdering()
        {
            using (var context = new TestCRM())
            {
                var persons = context.Persons;
                //Try get oldest Man and oldest Woman.
                var oldest = persons
                    .Where(p => p.Sex == Gender.Male || p.Sex == Gender.Female)
                    .GroupBy(p => p.Sex)
                    .Select(g => g.OrderBy(p => p.DateOfBirth));
                //Try get youngest Man and youngest Woman. 
                var youngest = persons
                    .Where(p => p.Sex == Gender.Male || p.Sex == Gender.Female)
                    .GroupBy(p => p.Sex)
                    .Select(g => g.OrderByDescending(p => p.DateOfBirth));
                var oldestMales = oldest.Where(x => x.All(q => q.Sex == Gender.Male)).FirstOrDefault();
                var oldestFemales = oldest.Where(x => x.All(q => q.Sex == Gender.Female)).FirstOrDefault();
                var oldestWoman = oldestFemales.FirstOrDefault();
                var oldestMan = oldestMales.FirstOrDefault();
                var youngestMales = youngest.Where(x => x.All(q => q.Sex == Gender.Male)).FirstOrDefault();
                var youngestFemales = youngest.Where(x => x.All(q => q.Sex == Gender.Female)).FirstOrDefault();
                var youngestWoman = youngestFemales.FirstOrDefault();
                var youngestMan = youngestMales.FirstOrDefault();                
                Assert.AreEqual(oldestWoman.Name, "Navya"); //Oldest Woman
                Assert.AreEqual(oldestMan.Name, "Pranav"); //Oldest Man (Note: last() gets the second grouping)
                Assert.AreEqual(youngestMan.Name, "Aditya"); // Youngest Man.
                Assert.AreEqual(youngestWoman.Name, "Ananya"); // Youngest Woman.
            }
        }
