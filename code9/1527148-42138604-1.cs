    public event AcquiredDataEvent OnNewAcquiredData
    {
       add { Console.WriteLine("Trying to attach some handlers?"); }
       remove { Console.WriteLine("Haha, you should attach something first!"); }
    }
