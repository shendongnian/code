    public class PlayerBase 
    {
         protected SomeClass clip;
         public void PlaySound()
         {
             AudioManager.Play(clip);
         }
    }
    class Player : PlayerBase {}
    class GameManger : PlayerBase {}
