    private List<Carro> Carros;
    
    public Form1()
    {
        Carros = new List<Carro>();
        ..
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        ..
    }
    
    private void AdicionarCarro()
    {
        var carro = new Carro(textboxCor.Text, textboxMarca.Text, textboxModelo.Text,
            (int.Parse(numUpDownCilindrada.Text)), (int.Parse(numUpDownVelocidade.Text)));
        Carros.Add(carro);
    }
    
    private void buttonGravar_Click(object sender, EventArgs e)
    {
        AdicionarCarro();
    }
