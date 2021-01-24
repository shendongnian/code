    StringBuilder sb = new StringBuilder();
            for (int i = 0; i < splitfirsts.Length; i++)
            {
                sb.AppendFormat("{0}{1}{2}{3}{4}",
                  X[i], A[i], B[i], C[i], D[i]);
                
            }
    Console.Write(sb);
