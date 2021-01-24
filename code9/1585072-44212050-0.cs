        public bool HasChanged(ObservableCollection<string> listStandings, ObservableCollection<string> newListStandings)
        {
            if (listStandings.Count != newListStandings.Count)
                return true;
            for (int i = 0; i < listStandings.Count; i++)
                if (listStandings[i] != newListStandings[i])
                    return true;
            return false;
        }
