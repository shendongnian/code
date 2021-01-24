    // For Process B Read
    accessor.Write(499, 41);
    // For Process B Read
    accessor.Write(503, 42);
    // For Process C Read
    accessor.Write(507, 43);
    Console.WriteLine("Process A Int:{0}", access.ReadInt32(499));
    Console.WriteLine("Process B Int:{0}", access.ReadInt32(503));
    Console.WriteLine("Process C Int:{0}", access.ReadInt32(507));
