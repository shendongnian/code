    class HalloForm : Form
    {
        public int a, b, c = 0; //Declare them here.
        public HalloForm()
        {
            this.Text = "Hallo";
            this.BackColor = Color.Yellow;
            this.Size = new Size(800, 600);
            this.Paint += this.tekenScherm;
        }
    
        public static void Main()
        {
            System.Console.WriteLine("Smiley size, on a scale of 1 tot 10?");
            a = Int32.Parse(System.Console.ReadLine());
            System.Console.WriteLine("X coordinate of the smiley, on a scale of 1 to 10");
            b = Int32.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Y coordinate of the smiley, on a scale of 1 to 10");
            c = Int32.Parse(System.Console.ReadLine());
            HalloForm scherm;
            scherm = new HalloForm();
    
            Application.Run(scherm);
        }
        void tekenScherm(object obj, PaintEventArgs pea)
        {
    
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            Pen blackBrush = new Pen(Color.Black, 5);
            int x = 360;
            int y = x + 75;
            pea.Graphics.FillEllipse(blueBrush, 300, 200, 200, 200);
            pea.Graphics.DrawEllipse(blackBrush, 300, 200, 200, 200);
            pea.Graphics.DrawArc(blackBrush, 350, 250, 100, 100, 45, 90);
            pea.Graphics.DrawEllipse(blackBrush, x, 250, 5, 5);
            pea.Graphics.DrawEllipse(blackBrush, y, 250, 5, 5);
        }
    }
