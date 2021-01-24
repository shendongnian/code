     public static ulong[] productFib(ulong prod)
        {
            ulong F1 = 0;
            ulong F2 = 1;
            ulong t = 0;
            while (F1 * F2 < prod)
            {
                t = F1 + F2;
                F1 = F2;
                F2 = t;
               
            }
            ulong[] fib;
            if (F1*F2 == prod)
            {
                fib = new ulong[3] { F1, F2, 1 };
            }else
            {
                fib = new ulong[3] { F1, F2, 0 };
            }
          
            return fib;
        }
