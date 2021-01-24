    //C#-ish pseudocode based on OPs example; doesn't compile
	class frmProgress : Form
	{
		// Standard stuff
		public void DoSomeWorks()
		{
			async Task.Run(() => RunWork1());
			ShowDialog();
		}
		void RunWork1()
		{
			// Do a lot of things including update UI
			if (_iLikeTheResultOfWork1)
			{
				async Task.Run(() => RunWork2());
			}
			else
			{
                Hide();
			}
		}
		void RunWork2()
		{
			// Do a lot of things including update UI
			Hide();
		}
	}
