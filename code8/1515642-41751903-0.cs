    public static class Program {
        
        public static Form1 Form1 { get; private set; }
        public static Form2 Form2 { get; private set; }
        
        public static Int32 Main(String[] args) {
            
            using( Program.Form1 = new Form1() )
            using( Program.Form2 = new Form2() ) {
            
                Application.Run( Program.Form1 ); // Form1's `Load` method would then show `Form2`
            }
            Program.Form1 = Program.Form2 = null;
            
            return 0;
        }
    }
    
