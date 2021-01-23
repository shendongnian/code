    class Content {            
        public void Delay1(Action<string> callback) {
            //something which takes 5000ms
            callback("hello");
        }
        public void Delay2(Action<string> callback) {
            //something which takes 5000ms
            callback("hello");
        }
        public void Delay3(Action<string> callback) {
            //something which takes 5000ms
            callback("hello");
        }
        public void Print(Action callback) {
            Delay1(() => {
                Delay2(() => {
                    Delay3(() => callback())
                })
            });
        }
    }
