    List<Ocjene> listaOcjenaDjeteta = new List<Ocjene>();
    listaOcjenaDjeteta.AddRange(ocjeneDjeteta.DohvatiOcjene(svaDjeca[int.Parse(clickedItem.Name)].IdDjeteta));// Add first List
    listaOcjenaDjeteta.AddRange(ocjeneDjeteta.DohvatiProfesore2());// Add second List
    dataGridViewMojaDjeca.DataSource = listaOcjenaDjeteta;
    dataGridViewMojaDjeca.Refresh();
