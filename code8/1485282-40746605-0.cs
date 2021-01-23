    string[] f1 = Directory.GetFiles("path1");
    string[] f2 = Directory.GetFiles("path2");
    var unique_f1 = f1.Except(f2).ToArray();
    var unique_f2 = f2.Except(f1).ToArray();
    int f1_size = unique_f1.Length;
    int f2_size = unique_f2.Length;
    int list_length = 0;
    if (f1_size > f2_size)
    {
        list_length = f1_size;
        Array.Resize(ref unique_f2, list_length);
    }
    else
    {
        list_length = f2_size;
        Array.Resize(ref unique_f1, list_length);
    }
    using (StreamWriter writer = new StreamWriter("output.txt"))
    {
        writer.WriteLine(string.Format("{0,-30}{1,-30}", "Unique in fdr1", "Unique in fdr2"));
        for (int i = 0; i < list_length; i++)
        {
            writer.WriteLine(string.Format("{0,-30}{1,-30}", unique_f1[i], unique_f2[i]));
        }
    }
