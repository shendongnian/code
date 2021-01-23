    void foo(A*& a)
    { 
         // Here you can change object's state
         // Also you can change value of pointer
         // Caller will have new value of pointer
    }
    void foo(A* a)
    {
        // Here you can change object's state
        // Also you can change value of copy of pointer
        // Caller will have old value of pointer
    }
