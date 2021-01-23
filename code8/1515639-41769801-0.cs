	public class GroupedDisciplines : ObservableCollection<Disciplines>
	{
		public string Title { get; set; }
		public static ObservableCollection<GroupedDisciplines> CreateGroup (ObservableCollection<Module> module)
		{
			var group = new GroupedDisciplines();
			var colection = new ObservableCollection<GroupedDisciplines>();
			foreach (Module m in module)
			{
				group = new GroupedDisciplines() { Title = m.Title };
				foreach (Discipline d in module.SelectMany(x => x.Disciplines))
				{
					group.Add(d);
				}
				colection.Add(group);
			}
			return colection;
		}
	}
