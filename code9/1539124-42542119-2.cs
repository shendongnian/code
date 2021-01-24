    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace xyz
    {
        
        public class C {
            public void M() {
                IMagic1<double> x = new X1();
                var y = (IMagic2<int>)x;
            }
        }
        
        public class X1 : IMagic1<double> {
            public IMagic2<double> Magic() {
                return new X2();
            }        
        }
        
        public class X2 : IMagic2<double> {
            public void Magic2() {
                
            }        
        }
        
        public interface IMagic1<T> {
           IMagic2<T> Magic();
        }
        
        public interface IMagic2<T> {
            void Magic2();
        }
            
        public class Program
        {
            public static void Main(string[] args)
            {
                new C().M();
            }
        }
    }
