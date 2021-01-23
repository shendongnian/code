    public interface IConvertable
    {
        bool TryConvertTo<TTarget>(out TTarget entity)
            where TTarget: Entity, IConvertable
    }
