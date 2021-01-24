    Console.WriteLine($"You have now entered the 2017 Wimbledon tournament!\n");
    var tournamentTypeSelector = new OptionSelector<TournamentType>()
        .WithOption(TournamentType.Default, "Default tournament")
        .WithOption(TournamentType.SingleWomen, "Women's single")
        .WithOption(TournamentType.SingleMen, "Men's single")
        .WithOption(TournamentType.DoubleWomen, "Women's double")
        .WithOption(TournamentType.DoubleMix, "Mix double");
    while (!tournamentTypeSelector.SelectOption()) { /*Console.Clear();*/ }
    var tournamentType = tournamentTypeSelector.SelectedOption;
    var actionSelector = new OptionSelector<Action>()
        .WithOption(() => StartTournament(tournamentType), "Start the tournament")
        .WithOption(() => Console.WriteLine("Not implemented"), "List players by first name")
        .WithOption(() => Console.WriteLine("Not implemented"), "List players by last name");
    while (!actionSelector.SelectOption()) { /*Console.Clear();*/ }
    actionSelector.SelectedOption(); // invoke selected action
