				namespace ConsoleApplication7
				{
					class Program
					{
						static void Main()
						{
							List<ChildModel> list = new List<ChildModel>();
							list.Add(new ChildModel { Title = "a", Id = 1 });
							list.Add(new ChildModel { Title = "b", Id = 1 });
							list.Add(new ChildModel { Title = "a", Id = 1 });
							var x = list.Distinct(new ChildModelComparer()).ToList();
							var y = x; //This has only got two child items.
							
						}
					}
					class ChildModelComparer : IEqualityComparer<ChildModel>
					{
						public bool Equals(ChildModel x, ChildModel y)
						{
							return x.Id.Equals(y.Id) && x.Title.Equals(y.Title);
						}
						public int GetHashCode(ChildModel obj)
						{
							if (string.IsNullOrEmpty(obj.Title) && obj.Id == 0)
							{
								return 0;
							}
							return $"{obj.Id}{obj.Title}".GetHashCode();
						}
					}
					public class ChildModel
					{
						public string Title { get; set; }
						public long Id { get; set; }
					}
				}
