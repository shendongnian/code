    public abstract class Animal : ITalkative, IFeedable
    {
         public Animal(AudioPlayer audioPlayer)
         {
              AudioPlayer = audioPlayer;
         }
    
         private AudioPlayer AudioPlayer { get; }
    
         public abstract void Feed(Food food);
    
         public void Talk()
         {
               // Probably you would want to load an animal sound library
               // here, and later pass the audio player with the sound library
               // already loaded
               OnTalk(AudioPlayer.LoadLibrary("animals"));
         }
    
         protected abstract void OnTalk(AudioLibrary audioLibrary);
    }
    public sealed class Cat : Animal
    {
          public Cat(AudioPlayer audioPlayer) : base(audioPlayer) 
          {
          }
          public override void Feed(Food food)
          {
               if(food is Vegetable)
               {
                    throw new NotSupportedException("MeeEEEEooW (=O ò.ó)=O!!");
               }
               else if(food is Meat)
               {
                   // Proceed to eat this meat!
               }
          }
          protected override void OnTalk(AudioLibrary audioLibrary)
          {
                audioLibrary.Play("sweet-cat");
          }
    }
