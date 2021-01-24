    namespace Ploeh.StackOverflow.Q47914153.Geo.Fakes
    {
        public class State : MySpace.State
        {
            private State()
            {
            }
    
            public static State Create()
            {
                return new Fixture().Build<State>().FromFactory(() => new State()).Create();
            }
        }
    }
