        static void Main(string[] args)
        {
            Random r = new Random();
            int max = 15;
            double[] x = new double[max];
            double[] y1 = new double[max];
            double[] y2 = new double[max];
            for (int i = 0; i < max; i++)
            {
                x[i] = i;
                y1[i] = r.Next(0, 50);
                y2[i] = r.Next(50, 100);
            }
            ScatterplotView spv = new ScatterplotView();
            spv.Dock = DockStyle.Fill;
            spv.LinesVisible = true;
            spv.Graph.GraphPane.AddCurve("Curve 1", x, y1, Color.Red, SymbolType.Circle);
            spv.Graph.GraphPane.AddCurve("Curve 2", x, y2, Color.Blue, SymbolType.Diamond);
            spv.Graph.GraphPane.AxisChange();
            
            Form f1 = new Form();
            f1.Width = 600;
            f1.Height = 400;
            f1.Controls.Add(spv);
            f1.ShowDialog();
            Console.ReadLine();
        }
