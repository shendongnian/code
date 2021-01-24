    List<AbonatTelefonic> listaAbonati;
    public PreluareDate()
    {
        ///GENERARE COLECTIE DE OBIECTE
        listaAbonati = new List<AbonatTelefonic>();
        listaAbonati.Add(a1);
        listaAbonati.Add(a3);
        listaAbonati.Add(a2);
        listaAbonati.Sort();
    }
    private void comboBox1_nume_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (AbonatTelefonic at in listaAbonati)
            MessageBox.Show(at.YourDesiredPropertyNameGoesHere);
    }
