    Stopwatch rotorSpeed = new Stopwatch();
    List<double> list = new List<double>();
    double av;
    int i = 0;
    private void button1_Click(object sender, EventArgs e)
    {
        i++;
        do
        {
            if (rotorSpeed.IsRunning)
            {
                rotorSpeed.Stop();
                list.Add(rotorSpeed.ElapsedMilliseconds);
                continue;
            }
            else
            {
                rotorSpeed.Reset();
                rotorSpeed.Start();
            }
            i=0;
        } while (i == 2);
        av = list.Average();
        textBox1.Text = av.ToString();
    }
}
