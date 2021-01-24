        lvwCarros.Columns.Clear();
        
        int idx, idx2;
        lvwCarros.Columns.Add("Carro", 80, HorizontalAlignment.Center);
        lvwCarros.Columns.Add("Ano", 60, HorizontalAlignment.Center);
        lvwCarros.Columns.Add("Stand", 60, HorizontalAlignment.Center);
        lvwCarros.Columns.Add("Localização do Stand", 120, HorizontalAlignment.Center);
        for (idx = 0; idx < Program.Carros.Count  ; idx++)
        {
           /* You should initiate a new item in the loop if you want to add more*/
           ListViewItem lvi = new ListViewItem();
            lvi.Text = Program.Carros[idx].Marca + " " + Program.Carros[idx].Modelo;
            for (idx2 = 0; idx2 < Program.Matriculas.Count  ; idx2++)
            {
                if (Program.Carros[idx].Matricula == Program.Matriculas[idx2].ID_Matricula)
                {
                    lvi.SubItems.Add(Program.Matriculas[idx2].Ano_Emissão.ToString());
                    for (int idx3 = 0; idx3 < Program.Stands.Count; idx3++)
                    {
                        if (Program.Carros[idx].Proprietario == Program.Stands[idx3].ID_Stand)
                        {
                            lvi.SubItems.Add(Program.Stands[idx3].Nome_Stand);
                            lvi.SubItems.Add(Program.Stands[idx3].Local_Stand);
                        }
                       
                    }
                } 
            }
            /*Moving it to outermost for loop*/
            lvwCarros.Items.Add(lvi);
        }
        lvwCarros.Visible = true;
        lvwCarros.Enabled = true;
