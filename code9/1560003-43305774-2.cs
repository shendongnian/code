	class Program {
		static void Main() {
			SortedList<Employee> list = new SortedList<Employee>();
			list.Insert(new Employee() { Name = "Zach" });
			list.Insert(new Employee() { Name = "Neil" });
			list.Insert(new Employee() { Name = "Barry" });
			foreach (var item in list) {
				Console.WriteLine(item.Name);
			}
		}
	}
	public class Employee : IComparable<Employee> {
		public string Name { get; set; }
		public int Age { get; set; }
		public Employee() {
		}
		public int CompareTo(Employee other) {
			return string.Compare(Name, other.Name, true);
		}
	}
	public class EmployeeAgeComparer : IComparer<Employee> {
		public int Compare(Employee x, Employee y) {
			return x.Age - y.Age;
		}
	}
	public class SortedList<T> : IEnumerable<T> {
		private List<T> _list;
		public List<T> List {
			get { return _list; }
			set { _list = value; }
		}
		private EmployeeAgeComparer EmployeeComparer = new EmployeeAgeComparer();
		public SortedList() {
			_list = new List<T>();
		}
		public void Insert(T item) {
			if (!_list.Contains(item)) {
				_list.Add(item);
				Sort(_list);
			}
		}
		private void Sort(List<T> list) {
			if (typeof(T) == typeof(Employee))
				list.Sort((IComparer<T>)EmployeeComparer);
			else
				list.Sort();
		}
		public IEnumerator<T> GetEnumerator() {
			return _list.GetEnumerator();
		}
		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
