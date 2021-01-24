    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication4
    {
        public class Program
        {
            static void Main(string[] args)
            {
                List<Student> students = new List<Student>();
                students.Add(new Student("s1", 140));
                students.Add(new Student("s2", 200));
                students.Add(new Student("s3", 250));
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
                if(!File.Exists(@"c:\Users\IIG\Desktop\demo.txt"))
                {
                    using (File.Create(@"c:\Users\IIG\Desktop\demo.txt"))
                    {
                        
                    }
                    
                }
                using (var writer = new StreamWriter(@"c:\Users\IIG\Desktop\demo.txt"))
                {
                    xmlSerializer.Serialize(writer,students);
                }
                PrintData();
            }
            [Serializable]
            public class Student
            {
                public string ID { get; set; }
                public double Score { get; set; }
    
                public Student()
                {
                    
                }
                public Student(string SID, double SC)
                {
                    ID = SID;
                    Score = SC;
                }
                public void DisplayInfo()
                {
                    Console.WriteLine(ID+ ": " + Score);
                }
            }
            public static void PrintData()
            {
                using (var readtext = new StreamReader(@"c:\Users\IIG\Desktop\demo.txt"))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
                    List<Student> readStudents = (List<Student>)xmlSerializer.Deserialize(readtext);
                    foreach (var student in readStudents)
                    {
                        student.DisplayInfo();
                    }
    
                }
            }
        }
    }
