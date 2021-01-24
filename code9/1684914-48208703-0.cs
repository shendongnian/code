    using (StreamWriter print = new StreamWriter("LOG {0}.txt", id))
    {
        print.WriteLine("LOG ID {0}\n\n", id);
        for (int i = 0; i < output.Capacity; i++)
        {
            print.WriteLine(output.ElementAt(i));
        }
    }
