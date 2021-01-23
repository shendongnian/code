    [Test]
        public void LinqSelect_MultipleRowsWithTheSameId_RemoveDuplicatedRecords()
        {
            var excel = new [] {new Student() {ID = 1,Exam = 1}, new Student() { ID = 1, Exam = 2 }, new Student() { ID = 2, Exam = 1 } };
            var Students_var = from c in excel
                               group c by c.ID into newExcel
                           select newExcel;
            Assert.AreEqual(2, Students_var.ToList().Count);
        }
        public class Student
        {
            public int ID { get; set; }
            public int Exam { get; set; }
        }
