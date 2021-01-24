      public class Pessoa
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public override string ToString()
            {
                return this.Nome.ToString();
            }
        }
        List<Pessoa> lista = new List<Pessoa>();
        private void Form1_Load(object sender, EventArgs e)
        {
            lista.Add(new Pessoa() { Nome = "Rovann1", Email = "Teste1@Teste.com" });
            lista.Add(new Pessoa() { Nome = "Rovann2", Email = "Teste2@Teste.com" });           
            lista.Add(new Pessoa() { Nome = "Rovann3", Email = "Teste3@Teste.com" });
            listBox1.DisplayMember = "Nome";
            listBox1.DataSource = lista;
            
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = "Select one item";
            //1
            if (listBox1.SelectedItem != null)
            {
                label1.Text = ((Pessoa)listBox1.SelectedItem).Email;
            }
            //2
            Pessoa p = lista.Find(x => x.Nome == listBox1.SelectedItem.ToString());
            if (p != null)
                label1.Text = p.Email;
            //3
            if (listBox1.SelectedIndex >= 0)
                label1.Text = lista[listBox1.SelectedIndex].Email;
        }
