                List<Panel> PanelList = new List<Panel>();
            for (int i = 0; i < 36; i++)
            {
                Panel p = new Panel();
                p.Name = ($"Panel{i}");
                p.BackColor = Color.Black;
                PanelList.Add(p);
            }
