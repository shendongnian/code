    Thread checkIfDead = new Thread(CheckIfDead);
            checkIfDead.Start();
    public void CheckIfDead()
        {
            while (true)
            {
                if (Health <= 0)
                {
                    Dead = true;
                }
            }
        }
