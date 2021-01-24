    public class Info
    	{
    		public string course { get; set; }
    		public int grade { get; set; }
    
    		public Info(string c, int g)
    		{
    			course = c;
    			grade = g;
    		}
    
    	}
    
    	public class Student
    	{
    		public Dictionary<string,Dictionary<string,int>> student { get; set; }
    		public Student()
    		{
    			student = new Dictionary<string, Dictionary<string, int>>();
    		}
    
    		/// <summary>
    		/// 
    		/// </summary>
    		public void SetValue(string studentName, Info info)
    		{
    			
    			if (!student.ContainsKey(studentName))
    			{
    				Dictionary<string, int> stud_info = new Dictionary<string, int>();
    				stud_info.Add(info.course, info.grade);
    				student.Add(studentName, stud_info);
    			}
    			else
    			{
    				student[studentName].Add(info.course, info.grade);
    			}
    		}
    
    
    		public Dictionary<string,int> GetValue(string studentName, string course)
    		{
    			Dictionary<string, int> info = new Dictionary<string, int>();
    			if (student.ContainsKey(studentName))
    			{
    				if (student[studentName].ContainsKey(course))
    				{
    					int grade = 0;
    					if(student[studentName].TryGetValue(course, out grade))
    					{
    						info.Add(course, grade);
    						return info;
    					}
    				}
    			}
    			return info;
    		}
    	}
    
    	public class Program
    	{
    		public static void Main(string[] args)
    		{
    			Student student = new Student();
    			Info i1 = new Info("math", 9);
    			student.SetValue("Student1", i1);
    			Info i2 = new Info("science", 11);
    			student.SetValue("Student1",i2);
    			Info i3 = new Info("math", 13);
    			student.SetValue("Student2", i3);
    
    			Dictionary<string, int> value = student.GetValue("Student2", "math");
    			//Grade of math for student2
    			Console.WriteLine("Grade: {0}", value["math"]);
    		}
    
    		
    	}
