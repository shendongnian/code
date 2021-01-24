    private void button2_Click(object sender, EventArgs e)
        {
            List<int> lista = new List<int>();
            foreach (string x in listBox1.Items)
            {
                lista.Add(Convert.ToInt32(x));
            }
            lista.Sort();
            foreach (int a in lista)
            {
                listBox2.Items.Add(a);
            }
        }
