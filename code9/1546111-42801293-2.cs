    private void SetDifficulty(Difficulty difficulty) {
        // this auto clears everything
        CardList = new ObservableCollection<Card>();
        //Switching on the diff
        switch (difficulty) {
            case Difficulty.Easy:
                // set the width in each level of difficulty to allow wrapper to make nice looking grid
                CollWidth = 200; // (button width is 50) * 4 buttons = 200
                for(int i=0;i<16;i++)
                    CardList.Add(new Card()); // or whatever constructor
                break;
            case Difficulty.Medium:
                CollWidth = 250; // (button width is 50) * 5 buttons = 250
                for(int i=0;i<25;i++)
                    CardList.Add(new Card()); // or whatever constructor
                break;
            case Difficulty.Hard:
                CollWidth = 300; // (button width is 50) * 6 buttons = 300
                for(int i=0;i<36;i++)
                    CardList.Add(new Card()); // or whatever constructor
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(difficulty), difficulty, null);
        }
    }
