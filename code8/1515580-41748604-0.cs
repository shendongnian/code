    extern "C" {
      __declspec(dllexport) BOOL __stdcall GetAllConsoleParameters(AllParameters *pItem)
      {
        pItem->Parameters[0].Index = 0;
        pItem->Parameters[0].Id = 42;
        CopyMemory(&pItem->Parameters[0].Value[0], "Hello World", 12);
        pItem->Parameters[1].Index = 1;
        pItem->Parameters[1].Id = 43;
        CopyMemory(&pItem->Parameters[1].Value[0], "Hello World 43", 15);
        return TRUE;
      }
    }
