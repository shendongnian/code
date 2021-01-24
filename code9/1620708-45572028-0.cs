    var loc = Server.MapPath("~/Data/locations.csv");
    if (System.IO.File.Exists(loc))
    {
        string[] lines = System.IO.File.ReadAllLines(loc);
        foreach (string line in lines)
        {
            string[] data = line.Split(',');
            if (data[1] == "1")
            {
                locations.Add(new SelectListItem { Text = data[0], Value = data[0] });
            }
        }
    }
