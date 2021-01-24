    public class C {
        public void M() {
            IMagic1<double> x = null;
            var y = (IMagic2<int>)x;
        }
    }
    
    public interface IMagic1<T> {
       IMagic2<T> Magic();
    }
    
    public interface IMagic2<T> {
        void Magic2();
    }
