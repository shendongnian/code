        IList<string> ruas = new List<string>();
        foreach (var element in Gdriver.FindElements(By.ClassName("search-title")))
        {
            ruas.Add(element.Text);
        }
        IList<string> codps = new List<string>();
        foreach(var Codpelement in Gdriver.FindElements(By.ClassName("cp")))
        {
            codps.Add(Codpelement.Text);
        }
        IList<string> Distritos = new List<string>();
        foreach (var Distritoelement in Gdriver.FindElements(By.ClassName("local")))
        {
            Distritos.Add(Distritoelement.Text.Substring(Distritoelement.Text.LastIndexOf(',') + 1));
        }
        for (int i = 0; i < ruas.Count; i++) {
            table.Rows.Add(ruas.ElementAt(i), codps.ElementAt(i), Distritos.ElementAt(i));
        }
