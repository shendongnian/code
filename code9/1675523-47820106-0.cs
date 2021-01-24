    class Implementation<T> : IVMBase<T>
        where T : Entit
    {
        // "explicit implementation" of the IVMBase property:
        RelayCommand<ChangeHierarchyParentArgs<Entity>> IVMBase.ChangeEntityParent
        {
            get { ... }
            set { ... }
        }
        // normal implementation of the IVMBase<T> property:
        public RelayCommand<ChangeHierarchyParentArgs<T>> ChangeEntityParent
        {
            get { ... }
            set { ... }
        }
    }
