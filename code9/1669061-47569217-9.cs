    using System.Linq;
    public class StudentRepository {
		public StudentRepository() {
		   _studentsByName = new Dictionary<string, Student>();
		}
       // keep data store private so we can change the implementation
       private IDictionary<string, Student> _studentsByName {get; set;}
    
		public void Add(Student student) {
			if (_studentsByName.ContainsKey(student.Name)) {
			   throw new ArgumentException($"Student '{student.Name}' already stored.");
			}
			_studentsByName.Add(student.Name, student);
		}
		
		public Student Get(string studentName) {
			if (_studentsByName.ContainsKey(studentName)) {
			   return _studentsByName[studentName];
			}
			throw new ArgumentException("No student '" + studentName + "' stored.");
		}
	   // Find Grade for certain student and course
       public int GetGrade(string studentName, string course) {
			if (_studentsByName.ContainsKey(studentName)) {
				var student = _studentsByName[studentName];
				var courseInfo = student.Infos.FirstOrDefault(i => i.Course == course);
				if (courseInfo != null) {
					return courseInfo.Grade;
				}
				else {
					throw new ArgumentException(
                        $"Student '{studentName}' did not take the course '{course}'.");
				}
			}
			else {
				throw new ArgumentException($"No student '{studentName}' found.");
			}
		}
		
		// Get dictionary of all students that took a certain course. Key: student name
		public IDictionary<string, Info> GetCoursesByStudentName(string course) {
		
		    // Use LINQ to retrieve the infos you need. 
			// Here I create a new dictionary with Student name as Key and 
			// the first matching course info found as value.
			// (Students that did not take this course are not in this dictionary):
		    return _studentsByName 
                .Where(kvp => kvp.Value.Infos.Any(i => i.Course == course))
				.ToDictionary(kvp => kvp.Key, 
                              kvp => kvp.Value.Infos.First(i => i.Course == course));
		}
    }
