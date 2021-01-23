    public class PlayerBase 
    {
         protected SomeClass clip;
         public void PlaySound()
         {
             AudioManager.Play(clip);
         }
    }
    Class Player : PlayerBase {}
    Class GameManger : PlayerBase {}
