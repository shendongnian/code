    //these are string[] (string arrays)
    var teams = File.ReadAllLines(teamsPath); // Assuming "TeamName" per line.
    var winners = File.ReadAllLines(winnersPath);// Assuming "YYYY TeamName" per line
    
    //add teams to list box
    for(var i = 0; i < team.Length; i++) {
        listBox1.Items.Add(teams[i]);
    }
