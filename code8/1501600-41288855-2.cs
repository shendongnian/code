    class Test 
    {
        int Main;
        void F()
        {
            {
                Main = 10; // means "this.Main"
            }
            for(whatever)
            {
                int Main = 100; // Access local Main
                {
                    int Main = 42; // Error!!!! It has a conflict with Main it outer scope.
                }
            }
        }
    }
