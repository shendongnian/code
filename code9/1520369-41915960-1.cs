        private const bool NumChoices = 5;
        ...
        int randomNumberPicker = Random.Range(0, NumChoices);
        switch (randomNumberPicker)
        {
            case 0:
                ZombieCard1 = Instantiate(Resources.Load("Frontcard1")) as GameObject;
                ZombieCard1.transform.Translate(0, -1, 0);
                if (leftChoice == true)
                {
                    Debug.Log("Jesus Marty! you fixed it! Great Scott!");
                }
                break;
            ...
        }
