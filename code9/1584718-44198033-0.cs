            List<Tuple<string, double, double>> ElmList = new List<Tuple<string, double, double>>();
    
            private void LoadTuple()
            {
    
                ElmList.Add(new Tuple<string, double, double>("Element 1", 0.0, 1.39));
                ElmList.Add(new Tuple<string, double, double>("Element 2", 1.4, 2.09));
                ElmList.Add(new Tuple<string, double, double>("Element 3", 2.1, 4.89));
                ElmList.Add(new Tuple<string, double, double>("Element 4", 4.9, 5.0));
    
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                double temp = double.Parse(textBox1.Text);
                var element = ElmList.FirstOrDefault(x => x.Item2 <= temp && x.Item3 >= temp);
                MessageBox.Show(element.Item1);
            }
