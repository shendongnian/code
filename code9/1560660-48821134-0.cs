            int[] Alice = { a0, a1, a2 };
            int[] Bob = { b0, b1, b2 };
            int alice = 0;
            int bob = 0;
            for (int i = 0; i < Alice.Length; i++)
            {
                if (Alice[i] > Bob[i])
                {
                    alice++;
                }
                if (Alice[i] < Bob[i])
                {
                    bob++;
                }
            }
            int[] result = { alice, bob };
            return result;
