	public class ReplayByHierarchyLevels : ReplayViewModelBase
	{
		// be aware may be null
		public bool levelOne { get{return HierarchyLevels.FirstOrDefault(x => x.Text == "levelOne").Selected;} }
		
		// rest the same
	} 
