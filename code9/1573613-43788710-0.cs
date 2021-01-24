    public string ToonGrenzenPerZoekwoord(string zoekwoord)
    {
        string list = "";/*"<h1> Resultaten via grenzen </h1> <br>";*/
        foreach (DataTable table in _persistcode.SearchGrenzenByKeyword("%" + zoekwoord + "%").Tables)
        {
            foreach (DataRow row in table.Rows)
            {
                list += "<p class='t1'>"; //using paragraph
                list += row["Grens"].ToString();
                list += ": <br>" + "</span>" + "<span class='t2'>";
                list += row["Sanctie"].ToString() + "<br> <br>";
                list += "Dit hoort thuis in de categorie: "; 
                list += row["IDCategorieën"].ToString();
                list += "</p>"; //ommited final <br>
            }
        }
        return list;
    }
