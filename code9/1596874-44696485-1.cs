     IList<string> Freguseia = new List<string>();
            foreach (var freguesiaelement in Fdriver.FindElements(By.ClassName("local")))
            {
                Freguseia.Add(freguesiaelement.Text);
            }
            IList<string> GPS = new List<string>();
            foreach (var gpselement in Fdriver.FindElements(By.ClassName("gps")))
            {
                GPS.Add(gpselement.Text);
            }
            for (int i = 0; i < Freguseia.Count; i++)
            {
                table.Rows.Add( Freguseia.ElementAt(i), GPS.ElementAt(i));
            }
