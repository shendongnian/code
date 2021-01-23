    class Test
    {
        int MainVar = 0;
        public void Main()
        {
            if (this.MainVar++ > 10) return;
            int MainVar = 10;
            Console.WriteLine($"Instance Main, this.MainVar=${this.MainVar}, MainVar=${MainVar}");
            void Main()
            {
                if (MainVar++ > 14) return;
                Console.WriteLine($"Local Main, this.MainVar=${this.MainVar}, MainVar=${MainVar}");
                // Here is a recursion you were looking for, in Example 1
                this.Main();
                // Let's try some errors!
                int MainVar = 110; // Error! Local MainVar is already declared in a parent scope. Error CS0136  A local or parameter named 'MainVar' cannot be declared in this scope because that name is used in an enclosing local scope to define a local or parameter
                void Main() { } // Error! the same problem with Main available on the parent scope. Error CS0136  A local or parameter named 'Main' cannot be declared in this scope because that name is used in an enclosing local scope to define a local or parameter
            }
            Main(); // Local Main()
            this.Main(); // Instance Main()
        }
    }
