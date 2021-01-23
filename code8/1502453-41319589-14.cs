    abstract class Token {};
    class EncapsulatingClass {
        private class PrivateToken : Token {};
        public Token method1()
        {
            //Method 1
            return new PrivateToken();
        }
        
        public void method2( Token token )
        {
            if ( ( token as PrivateToken ) == null ) {
                throw new ArgumentException();
            }
            //Method 2
        }
    }
