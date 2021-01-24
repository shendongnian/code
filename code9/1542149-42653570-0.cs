	public class Program
	{
		public static void Main()
		{
			var list = new List<Double?> { null, null, 2, 3, 4, null, null, 3, 3, null };
			var groupLists = new List<GroupList>();
			GroupList currentGroupList = null;
			
			for (var i = 0; i < list.Count; i++)
			{
				if (list.ElementAt(i).HasValue)
				{
					if (currentGroupList == null)
					{
						currentGroupList = new GroupList();
						currentGroupList.Start = i;
						groupLists.Add(currentGroupList);
					}
					currentGroupList.Items.Add(list.ElementAt(i).Value);
				}
				else
				{
					if (currentGroupList != null)
					{
						currentGroupList.End = i -1;
					}
					currentGroupList = null;
				}
			}
			
			
			foreach(var groupList in groupLists)
			{
				Console.WriteLine("{0} {1} [{2}]", groupList.Start, groupList.End, string.Join(",",groupList.Items.ToArray()));
			}
		}
		
		public class GroupList
		{
			public GroupList()
			{
				Items = new List<Double>();
			}
			
			public int Start { get; set; }
			public int End { get; set; }
			public List<Double> Items { get; set; }
		}
	}
