    using System;
    namespace hwapp {
        class Program {
            int numero;
            string titular;
            int saldo;
    
            static void Main(string[] args) {
                var c = new Program(); // OR Program c = new Program;
                c.numero = 12;
                c.titular = "João";
                c.saldo = 102;
        
                Console.WriteLine("Número: "+c.numero.ToString()+"\n");
                Console.WriteLine("Titular da conta: "+c.titular+"\n");
                Console.WriteLine("Salto: "+c.saldo.ToString()+"\n");
            }
        }
    }
