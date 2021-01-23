    class Test 
    {
        int Main;
        void F()
        {
            {
                Main = 10; // means "this.x"
            }
            for(whatever)
            {
                int Main = whatever; // Access local Main
                {
                    int Main = Something; // Error!!!!
                }
            }
        }
    }
