    public void DisplayList()
    {
        for (int i = 0; i < list.Length; i++)
        {
            if(list[i] != null){
                Console.Out.WriteLine("{0}: {1}", i, list[i].getFirstName());
            }
            else
            {
                Console.Out.WriteLine("{0}: [NULL]", i);
            }
        }
    }
