		public class Teacher
		{
			public Teacher()
			{
				this.isPassive = false;
			}
			public int ID { get; set; }
			public virtual Lesson Lesson { get; set; }
		}
		public class Lesson
		{
		    [Key, ForeignKey("Student")]
			public int ID { get; set; }
			
			public string Name { get; set; }
			
			public virtual Teacher Teacher { get; set;}
		}
