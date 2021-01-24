    Random random = new Random(); // new Random object
    int randomValue = random.Next(); // get new random value
    int oneOrZero = randomValue % 2; // get either 1 or zero
    string name = "";
    if ( oneOrZero == 0 ) // if value is zero
    {
        name = "-"; // name will contain minus sign
    }
    else 
    {
        name = "+"; // else name will contain plus sign
    }
