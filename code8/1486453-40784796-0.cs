    public class SomeViewModel : IEquatable<SomeModel>
    {
        bool IEquatable<SomeModel>.Equals(SomeModel model)
            => model != null && SomeProperty == model.SomeOtherProperty;
    }
