    using System;
    using System.Collections.Generic;
    
    namespace DoubleDispatch
    {
        interface KeyI
        {   // set to some output class like printer, plotter, screen
            void Output(); 
        }
    
        interface OutputterI
        {
            void Output(KeyA kA);
            void Output(KeyExtra kE);
            void Output(KeyI k); // whatever this does.
        }
    
        class KeyBase: KeyI
        {
            protected OutputterI o;
    
            public KeyBase(OutputterI oArg) { o = oArg; }
    
            // This will call Output(KeyI))
            public virtual void Output() { o.Output(this); }
        }
    
        class KeyA : KeyBase
        {
            public KeyA(OutputterI oArg) : base(oArg) { }
    
            public string GetAData() { return "KeyA Data"; }
    
            // This will compile to call Output(KeyA kA) because
            // we pass this which is known here to be of type KeyA
            public override void Output() { o.Output(this); }
        }
    
        class KeyExtra : KeyBase
        {
            public string GetEData() { return "KeyB Data"; }
            public KeyExtra(OutputterI oArg) : base(oArg) { }
    
            /** Some extra data which needs to be handled during output. */
            public string GetExtraInfo() { return "KeyB Extra Data"; }
    
            // This will compile to call o.Output(KeyI) because there is no 
            // OutputterI.Output(KeyBase)
            public override void Output() { o.Output(this); }
        }
    
        class KeyConsolePrinter : OutputterI
        {
            // Note: No way to print KeyBase.
            public void Output(KeyA kA) { Console.WriteLine(kA.GetAData());  }
            public void Output(KeyExtra kE)
            {
                Console.Write(kE.GetEData() + ", ");
                Console.WriteLine(kE.GetExtraInfo());
            }
            // default method for other KeyI
            public void Output(KeyI otherKey) { Console.WriteLine("Got an unknown key type"); }
    
        }
        // similar for class KeyScreenDisplayer{...} etc.
    
        class DoubleDispatch
        {
            static void Main(string[] args)
            {
    
                KeyConsolePrinter kp = new KeyConsolePrinter();
    
                KeyBase b = new KeyBase(kp);
                KeyBase a = new KeyA(kp);
                KeyBase e = new KeyExtra(kp);
    
                // Uninteresting, direkt case: We know at compile time
                // what each object is and could simply call kp.Output(a) etc.
                Console.Write("base:\t\t");
                b.Output();
    
                Console.Write("KeyA:\t\t");
                a.Output();
    
                Console.Write("KeyExtra:\t");
                e.Output();
    
                List<KeyI> list = new List<KeyI>() { b, a, e };
                Console.WriteLine("\nb,a,e through KeyI:");
    
                // Interesting case: We would normally not know which
                // type each element in the vector has. But each type's specific
                // Output() method is called -- and we know it must have
                // one because that's part of the interface signature.
                // Inside each type's Output() method in turn, the correct
                // OutputterI::Output() for the given real type was 
                // chosen at compile time dpending on the type of the respective
                // "this"" argument.
                foreach (var k in list) { k.Output(); }
            }
        }
    }
