        /// <summary>
        /// Due to bugs / magic in the ReactiveUI view locator we write our own.
        /// The ReactiveUI view locator causes errors if the ViewModel name
        /// doesn't end with "ViewModel". It ends up thinking the ViewModel
        /// and the View are the same class and then very bad stuff happens.
        /// </summary>
        public class WeinCadViewLocator : IViewLocator
        {
            private readonly IKernel _Kernel;
            public WeinCadViewLocator(IKernel kernel)
            {
                _Kernel = kernel;
            }
            public IViewFor ResolveView<T>(T viewModel, string contract = null) where T : class
            {
                Type generic = typeof(IViewFor<>);
                Type[] args = new[] {viewModel.GetType()};
                var realType = generic.MakeGenericType( args );
                if (contract == null)
                {
                    return (IViewFor) _Kernel.Get( realType );
                }
                else
                {
                    return (IViewFor) _Kernel.Get( realType, contract );
                }
                
            }
        }
