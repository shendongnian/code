    //Using arrays for simplicity, you get the idea.
    int[] A = { 1, 2, 3, 4, 5 };
    int[] B = { 6, 7, 8 };
    int[] C = { 9, 10, 11, 12 };
    List<int> ResultSet = new List<int>();
    //Determine this somehow. I'm doing this for simplicity.
    int longest = 5; 
    for (int i = 0; i < longest; i++)
    {
        if (i < A.Length)
            ResultSet.Add(A[i]);
        if (i < B.Length)
            ResultSet.Add(B[i]);
        if (i < C.Length)
            ResultSet.Add(C[i]);
    }
    //ResultSet contains: { 1, 6, 9, 2, 7, 10, 3, 8, 11, 4, 12, 5 }
