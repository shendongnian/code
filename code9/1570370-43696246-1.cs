    for (int m = 0; m < M; ++m)
        {
          for (int i = 0; i < C; i++)
            {
              Console.WriteLine("C " + m + "," + (i + 1) + " " + sumPj[m,i].Value);
              Constraint[m, i] = sumPj[m,i].Value;
            }
        }
