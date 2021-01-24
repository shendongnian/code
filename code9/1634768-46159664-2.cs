    void Update()
    {
            if (ChildTiles.Count(a => a.Color == Color.Green)>=4)
            {
                gameManager.finalGreenComplete = true;
                Debug.Log(gameManager.finalGreenComplete);
            }
    }
