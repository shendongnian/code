		public class Teacher
		{
			public Teacher()
			{
				this.isPassive = false;
			}
			public int ID { get; set; }
			public Nullable<int> LessonID { get; set; }
			[InverseProperty("Teachers")]
			[ForeignKey("LessonID")]
			public virtual Lesson Lesson { get; set; }
		}
		public class Lesson
		{
			public int ID { get; set; }
			public string Name { get; set; }
			
			[InverseProperty("Lesson")]
			public virtual ICollection<Teacher> Teachers { get; set;}
		}
