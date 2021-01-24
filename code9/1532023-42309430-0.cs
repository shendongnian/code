    if (Input.GetKeyDown(KeyCode.RightArrow))
    {
        if(selected.x<5)
        {
            selected=selected + new Vector3 (1,0,0);
        }
    }
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
        if(selected.x>-5)
        {
            selected=selected + new Vector3 (-1,0,0);
        }
    }
    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
        if(selected.z<5)
        {
            selected=selected + new Vector3 (0,0,1);
        }
    }
    if (Input.GetKeyDown(KeyCode.DownArrow))
    {
        if(selected.z>-5)
        {
            selected=selected + new Vector3 (0,0,-1);
        }
        // Here you can easily see that the closing bracket is missing.
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        print("escape");
        currentState=BattleStates.NONE;
        gameManager.GetComponent<gameManager>().PlayerChoice();
        gameManager.GetComponent<gameManager>().ShowMenu();
    }
    if (Input.GetKeyDown(KeyCode.Space))
    {
        print("pressed");
        destination=selected;
        currentState=BattleStates.NONE;
        gameManager.GetComponent<gameManager>().Resolution();
    }
