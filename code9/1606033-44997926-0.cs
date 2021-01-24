    private async Task ExecuteSearchAsync(string searchTerm, ObservableCollection<FlaggedPersonViewModel> searchBase, double searchSensitivity) {
        double lastNameScore, firstNameScore, distanceScore;
        await Task.Run
        (() => {
            foreach (FlaggedPersonViewModel person in searchBase) {
                lastNameScore = GetLevenshteinDistance(searchTerm, person.LastName, false);
                lastNameScore = (person.LastName.Length - lastNameScore) / person.LastName.Length;
                firstNameScore = GetLevenshteinDistance(searchTerm, person.FirstName, false);
                firstNameScore = (person.FirstName.Length - firstNameScore) / person.FirstName.Length;
                distanceScore = System.Math.Max(firstNameScore, lastNameScore);
                if (distanceScore > searchSensitivity)
                    person.IsResult = true;
                else
                    person.IsResult = false;
            }
        });
    }
