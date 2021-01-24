    TextAsset textAsset;
    switch (playerChoice) {
        case "PlayerOption1":
            textAsset = Resources.Load<TextAsset>("words1", typeof(TextAsset));
        break;
        case "PlayerOption2":
            textAsset = Resources.Load<TextAsset>("words2", typeof(TextAsset));
        break;
    }
    // and then the rest of your textAsset, 
    // handling code (splitting on linebreaks and .ToList())
            
