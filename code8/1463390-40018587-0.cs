    class Controller
    {
        ...
        public event EventHandler GameFinished;
        private bool gameOver;
        public bool GameOver 
        {
            get { return gameOver; }
            set
            {
                gameOver = value;
                if (gameOver)
                    GameFinished?.Invoke(this, new EventArgs());
            }
        }
    }
