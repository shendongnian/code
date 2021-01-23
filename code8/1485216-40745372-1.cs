            int Some { get; set; }
        }
    
        public abstract class BaseHamster : IHamster
        {
            public int Some { get; set; }
        }
    
        public class DerivedHamster : BaseHamster
        {
        }
    
        class ApplyHitHamster<T> where T : IHamster   // <-- same constraint 
        {
            void Zu()
            {
                BaseHamster hamster = null;
                var derived = new DerivedHamster();
                IHamster i = derived;
              
                var s = new TakeDamageHamster<T>(i); // <<<< Compilation Error on any variables(hamster,derived,i) WHY?????????
                var s2 = new TakeDamageHamster<IHamster>(i); // <<<< But THIS works well
            }
        }
    
        class TakeDamageHamster<T> where T : IHamster   // <-- same constraint 
        {
            private IHamster i;
    
            public TakeDamageHamster(T Hamster)
            {
                Console.WriteLine(Hamster.Some);
            }
    
            public TakeDamageHamster(IHamster i)
            {
                // TODO: Complete member initialization
                this.i = i;
            }
        }
