    public interface IHitService
    {
        IHit GetHit();
    }
    
    public interface IHit
    {
        IReadOnlyCollection<string> Result { get; }
    }
