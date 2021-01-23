     var result = new int[a.Length];
     var block2Length = a.Length - k;
     Array.Copy(a, k, result, 0, block2Length);
     Array.Copy(a, 0, result, block2Length, k);
        
     Console.WriteLine(string.Join(" ", result.Select(v => v.ToString())));
