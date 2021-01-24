    GCHandle pinnedA = GCHandle.Alloc(a, GCHandleType.Pinned);
    GCHandle pinnedB = GCHandle.Alloc(b, GCHandleType.Pinned);
    IntPtr pointerA = pinnedA.AddrOfPinnedObject();  
    IntPtr pointerB = pinnedA.AddrOfPinnedObject();
    double result = Managed.CopyDoubles(pointerA, pointerB);
    pinnedA.Free();
    pinnedB.Free();
