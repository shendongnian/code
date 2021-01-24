    public class GenericTypesWorkaroundInstance : Instance
    {
        private readonly Instance _target;
        private readonly Func<Type[], Type[]> _chooseTypes;
        public GenericTypesWorkaroundInstance(Instance target, Func<Type[], Type[]> chooseTypes) {
            _target = target;
            _chooseTypes = chooseTypes;
            ReturnedType = _target.ReturnedType;
        }
        public override Instance CloseType(Type[] types) {
            // close type correctly by ignoring wrong type arguments
            return _target.CloseType(_chooseTypes(types));
        }
        public override IDependencySource ToDependencySource(Type pluginType) {
            throw new NotSupportedException();
        }
        public override string Description => "Correctly close types over open generic instance";    
        public override Type ReturnedType { get; }
    }
