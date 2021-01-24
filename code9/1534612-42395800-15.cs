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
                if (index >= 0)
                {
                    usecases[index] = null;
                    usecases.RemoveAt(index);
                    panelUseCase.Invalidate();
                }
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(textBoxUseCaseName.Text)) // if name is typed into textbox
                {
                    _usecase = new UseCase()
                    {
                        Name = textBoxUseCaseName.Text,
                        X = x,
                        Y = y,
                        Field = new Rectangle(x, y, 40, 40)
                    };
                    usecases.Add(_usecase);
                    panelUseCase.Invalidate();
                }
                else
                {
                    MessageBox.Show("Need a Name for Usecase!");
                }
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
