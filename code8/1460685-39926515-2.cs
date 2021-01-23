    void Update () {
        string NewGuess = "Is it higher or lower than " +guess +"?";
        if (Input.GetKeyDown(KeyCode.Y)) {
            min = guess;
            guess = (max + min) / 2;
            NewGuess = "Is it higher or lower than " +guess +"?";
            print (NewGuess);
        } else if (Input.GetKeyDown(KeyCode.N)) {
            max = guess;
            guess = (max + min) / 2;
            NewGuess = "Is it higher or lower than " +guess +"?";
            print (NewGuess);
        } else if (Input.GetKeyDown(KeyCode.E)) {
            print ("I won!");
        }
    }
