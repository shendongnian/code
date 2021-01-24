    using System.Collections.Generic;
    using System.Linq;
    
    public class Xbonacci {
      public double[] Tribonacci(double[] signature, int n) {
        // hackonacci me
        // if n==0, then return an array of length 1, containing only a 0
        if (n == 0)
            return new double[] { 0 };
        else
            return Tribonacci(signature).Take(n).ToArray();
      }
      public IEnumerable<double> Tribonacci(double[] signature) {
          foreach (var n in signature)
              yield return n;
    
          var buffer = new Queue<double>(signature);
          while (true) {
              var next = buffer.Sum();
              yield return next;
              buffer.Dequeue();
              buffer.Enqueue(next);
          }
      }
    }
