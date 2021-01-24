	    `string[] X = Regex.Split(X, ",");
            string[] A = Regex.Split(A, ",");
            string[] B = Regex.Split(B, ",");
            string[] C= Regex.Split(C, ",");
            string[] D = Regex.Split(D, ",");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < splitfirsts.Length; i++)
            { 
              sb.AppendFormat("{0}{1}{2}{3}{4}",
                      X[i], A[i], B[i], C[i], D[i]);             
            }
            Console.WriteLine(sb.ToString());`
