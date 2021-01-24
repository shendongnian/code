    class ProcLauncher2 : BaseConverter, IProcLauncher
    {
        public DerivedClassForInterface GetNeededData()
        {
            var dataFromDb = new Proc2Result();/*just ilustrative*/
            //usage (works for single result or list if I need a list returned):
            return Convert<DerivedClassForInterface, Proc2Result>(dataFromDb);
        }
        //other methods...
    }
