    private void Form1_Load(object sender, EventArgs e)
    {
        sonep boi = new sonep(); //Instantiate like this
        maind p = new maind();
        p.Nom = txtnom.Text;
        p.Prenom = txtprenom.Text;
        boi.Insert(p);
    }
