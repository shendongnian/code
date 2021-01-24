    namespace My
    {
        public delegate void PopFunctionDoubleDelegate(DoubleArray^);
        public ref struct ProcessDoubleCLI abstract sealed
        {
            static double add_cli(PopFunctionDoubleDelegate^ delegate_func);
        };
    }
