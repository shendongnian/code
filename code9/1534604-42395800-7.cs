    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<UseCase> usecases = new List<UseCase>();
        int x, y;
        UseCase _usecase;
        private void panelUseCase_MouseClick(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            if (checkBoxDelete.Checked && usecases.Any())
            {
                int index = usecases.FindIndex(el =>
                x >= el.Field.Left && 
                x <= el.Field.Right && 
                y >= el.Field.Top && 
                y <= el.Field.Bottom
                );
                usecases[index] = null;
                usecases.RemoveAt(index);
                panelUseCase.Invalidate();
            }
            else
            {
                _usecase = new UseCase();
                _usecase.X = x;
                _usecase.Y = y;
                Rectangle rt = new Rectangle(x, y, 40, 40);
                _usecase.Field = rt;
                usecases.Add(_usecase);
                panelUseCase.Invalidate();
            }
        }
        private void panelUseCase_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panelUseCase.CreateGraphics();
            Pen p = new Pen(Color.Red);
            foreach (var el in usecases)
            {
                g.DrawEllipse(p, el.Field);
            }
        }
    }
