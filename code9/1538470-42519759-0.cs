    public class SomeBigOuterClass {
        private interface IChildFriend {
            void SetParent(Parent parent);
        }
    
        public class Parent {
        }
    
        public class Child : IChildFriend {
            void IChildFriend.SetParent(Parent parent) {
                this.parent = parent;
            }
            private Parent parent;
        }
    }
