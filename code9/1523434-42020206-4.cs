    namespace TestForm
    {
        class GetVertElementasList
        {
            private List<vertEl> vertElementList = new List<vertEl>();
    
            public List<vertEl> vertList(DataGridView VertElementer)
            {
                for (int i = 0; i < VertElementer.Rows.Count - 1; i++)
                {
                    vertElementList.Add(new vertEl
                    {
                        elNr = (int)VertElementer.Rows[i].Cells[0].Value,
                        p1 = (double)VertElementer.Rows[i].Cells[1].Value,
                        p2 = (double)VertElementer.Rows[i].Cells[2].Value,
                        z1 = (double)VertElementer.Rows[i].Cells[3].Value,
                        z2 = (double)VertElementer.Rows[i].Cells[4].Value,
                        heln1 = Convert.ToDouble(VertElementer.Rows[i].Cells[5].Value),
                        heln2 = (double)VertElementer.Rows[i].Cells[6].Value
                    });
                }
    
                return vertElementList;
            }
    
        }
         //Some other stuff
    }
