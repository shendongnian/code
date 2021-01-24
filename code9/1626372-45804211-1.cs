    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Ef6Test
    {
    
        public class Student
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string Name { get; set; }
    
            public virtual ICollection<StudentToClassRoom> StudentToClassRoom { get; set; } = new HashSet<StudentToClassRoom>();
        }
    
    
        public class StudentToClassRoom
        {
            
            [ForeignKey("Student"), Column(Order = 0), Key()]
            public int StudentId { get; set; }
    
            [ForeignKey("ClassRoom"), Column(Order = 1), Key()]
            public int ClassRoomId { get; set; }
    
            public virtual Student Student { get; set; }
    
            public virtual ClassRoom ClassRoom { get; set; }
        }
    
        public class ClassRoom
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        class Db: DbContext
        {
    
            public DbSet<Student> Students { get; set; }
            public DbSet<ClassRoom> Classrooms { get; set; }
    
            public DbSet<StudentToClassRoom> StudentToClassRoom { get; set; }
    
        }
        class Program
        {
            static void Main(string[] args)
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Db>());
    
                using (var db = new Db())
                    
                {
    
                    var students = Enumerable.Range(1, 150).Select(i => new Student() { Name = $"Student{i}" }).ToList();
                    var classRooms = Enumerable.Range(1, 20).Select(i => new ClassRoom() { Name = $"ClassRoom{i}" }).ToList();
    
                    var rand = new Random();
                    foreach( var s in students)
                    {
                        var classRoomId = rand.Next(0, classRooms.Count - 10);
                        s.StudentToClassRoom.Add(new StudentToClassRoom() { Student = s, ClassRoom = classRooms[classRoomId] });
                        s.StudentToClassRoom.Add(new StudentToClassRoom() { Student = s, ClassRoom = classRooms[classRoomId+1] });
                        s.StudentToClassRoom.Add(new StudentToClassRoom() { Student = s, ClassRoom = classRooms[classRoomId+2] });
    
                    }
    
                    db.Students.AddRange(students);
                    db.Classrooms.AddRange(classRooms);
                    db.SaveChanges();
    
                }
                using (var db = new Db())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    var q = db.Students.Include("StudentToClassRoom.ClassRoom");
    
                    var results = q.ToList();
                    Console.WriteLine(q.ToString());
    
    
                    Console.ReadKey();
                }
                
            }
        }
    }
