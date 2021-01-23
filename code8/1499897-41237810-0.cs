	public interface IMainUC
	{
		void AddDocument();
	}
	public class MainUC : XtraUserControl, IMainUC
	{
        ...
		public void AddDocument()
		{
			EditUC editUC = new EditUC(...);
			...
			this.documentManager.View.Add(editUC);
		}
        
        ...
	}
