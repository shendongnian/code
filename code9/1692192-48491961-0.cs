    public void GetScore() {
      Score += 1;
      blockGenerator.GenerateBlock();
      soundController.PlayBingo();
      Timer = initTimer;
     }
