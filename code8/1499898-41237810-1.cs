	public class CollectionUC : XtraUserControl
	{
		private readonly IMainUC m_mainUC;
		public CollectionUC(IMainUC mainUC)
		{
			m_mainUC = mainUC;
		}
		
		public void MyButtonClick(object sender, EventArgs e)
		{
			m_mainUC.AddDocument();
		}
	}
