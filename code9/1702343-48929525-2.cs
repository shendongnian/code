    void Start()
    {
        isOnline((online) =>
        {
            if (online)
            {
                Debug.Log("Connected to Internet");
                //internetMenu.SetActive(false);
            }
            else
            {
                Debug.Log("Not Connected to Internet");
            }
        });
    }
