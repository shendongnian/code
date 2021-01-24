    IList<string> Distritos = new List<string>();
    foreach (var Distritoelemen in Gdriver.FindElements(By.ClassName("local")))
    {
        //Distritos.Add(Distritoelement.Text);
        table.Rows.Add(Distritoelement.Text.Substring(Distritoelement.Text.LastIndexOf(',') + 1));
