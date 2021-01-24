            struct AorB
            {
                public static implicit operator AorB(A a) { ... }
                public static implicit operator AorB(B b) { ... }
            }
            void Method(AorB parameter)
