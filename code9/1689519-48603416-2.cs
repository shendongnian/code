	public partial class Form1 : Form
	{
		private WordEditControl wordEditControl1;
		public Form1()
		{
			InitializeComponent();
			wordEditControl1 = new WordEditControl();
			wordEditControl1.SetQuizText("The quick brown fox j___ed over the l__y hound");
            Controls.Add(wordEditControl1)
		}
	}
