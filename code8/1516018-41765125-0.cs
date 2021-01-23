        public override void Calculate(int index)
        {
            for (int i = 0; i < 7; i++)
            {
                if (a_gamma[i] == TAU[index])
                {
                    a_gamma_tau_health[i] = a_gamma[i];
                    TEST[i] = a_gamma[i];
                }
            }
        }
