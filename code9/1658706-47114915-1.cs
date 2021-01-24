    int rolledDice = -1;
    void Start()
    {
        rolledDice = rollingDice();
    }
    //This Function handles the rolling of the die. When called, it will generate a random number from; Random.Range between the number of 1 to 6, just like a die.
    int rollingDice()
    {
        int Dice = UnityEngine.Random.Range(0, 6);
        return Dice;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rolledDice = rollingDice();
            if (rolledDice == 6)
            {               //I've put the if statements here in update to check whether I've 
                            //rolled a 6 or not every frame.
                Debug.Log("You've hit the highest number!!");
            }
            else
            {
                Debug.Log("Your last roll was: " + rolledDice);
            }
        }
    }
