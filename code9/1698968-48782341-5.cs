    Ligne[] allLignes = DbContext.Lignes.ToArray(); // all possible options
    // for edit use case: the options that have been selected during create use case
    string[] previouslySelectedLigneCodes = new { "1", "3" }; 
    // your ViewModel containing the multiselect properties
    var vm = new MultiSelectViewModel(); 
    vm.AvailableOptions = new MultiSelectList(
        allLignes, "CodeLigne", "NomLigne", previouslySelectedLigneCodes);
