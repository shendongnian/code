    public interface II
        {
            void f();
        }
    
        #region Explicit
        public class AExplicit : II
        {
            void II.f() => Console.WriteLine(nameof(AExplicit));
        }  
    
        public class BExplicitIndependent : AExplicit
        {
            // void II.f() => Console.WriteLine("BExplicit"); // won't compile
            // f() does not hide anything - it's completely new method
            public void f() => Console.WriteLine("B that defines an independent method void f()");
        }
    
        public class BExplicitReImplemented : AExplicit, II
        {
            void II.f() => Console.WriteLine(nameof(BExplicitReImplemented));
        }
        #endregion Explicit
    
        #region Implicit
        public class AImplicit : II
        {
            public void f() => Console.WriteLine(nameof(AImplicit));
        }
    
        
        public class BImplicitIndependent : AImplicit
        {
            // WARNING: BImplicitReImplemented.f()' hides inherited member 'AImplicit.f()'. Use the new keyword if hiding was intended.
            public void f() => Console.WriteLine("B that defines an independent method void f()");
        }
    
        public class BImplicitReImplemented : AImplicit, II
        {
            public void f() => Console.WriteLine(nameof(BImplicitReImplemented));
        }
    
        #endregion Implicit
    
        class Program
        {
            static void Main(string[] args)
            {
                II AEasII = new AExplicit();
                II BEIndependentasII = new BExplicitIndependent();
                II BEasII = new BExplicitReImplemented();
                AExplicit BEIndependentasAE = new BExplicitIndependent();
                BExplicitIndependent BExplicitIndependentAsItself = new BExplicitIndependent();
                
                AEasII.f(); // IL: callvirt instance void xxx.II::f()
                BEIndependentasII.f(); // IL: callvirt instance void xxx.II::f()
                BEasII.f(); // IL: callvirt instance void xxx.II::f()
                // BEIndependentasAE.f(); no such method in A
                BExplicitIndependentAsItself.f(); // new method IL: callvirt instance void xxx.BExplicitIndependent::f()
    
                II AIasII = new AImplicit();
                II BIIndependentasII = new BImplicitIndependent();
                II BIasII = new BImplicitReImplemented();
                AImplicit BIIndependentAsAI = new BImplicitIndependent();
                BImplicitIndependent BIIndependentAsItself = new BImplicitIndependent();
    
                AIasII.f(); // IL: callvirt instance void xxx.II::f()
                BIIndependentasII.f(); // IL: callvirt instance void xxx.II::f()
                BIasII.f(); // IL: callvirt instance void xxx.II::f()
                BIIndependentAsAI.f(); // A method, but it has nothing to do with interfaces // IL: callvirt instance void xxx.AImplicit::f()
                BIIndependentAsItself.f(); // B method, but it also has nothing to do with interfaces // IL: callvirt instance void xxx.BImplicitIndependent::f()
            }
        }
