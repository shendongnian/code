    namespace ClassLibrary2 {
        public class Greeting {
            private readonly ISayGoodMorning speaker;
            public Greeting(ISayGoodMorning speaker) {
                this.speaker = speaker;
            }
    
            public string SayGreeting() {
                return speaker.GoodMorning();
            }
        }
    }
