    public interface IAbilityScore : IBaseEntity
    {
        string Name { get; set; }
    }
    
    public interface IBonus<T>
    {
        T Value { get; set; }
    }
    
    public interface IBonusable<T>
    {
        T Value { get; set; }
    }
    
    public interface ICharacterAbilityScore<T> : IBaseEntity, IBonusable<T>,IBonus<T>
    {
        ICharacter Character { get; set; }
        IAbilityScore AbilityScore { get; set; }
        bool IsSaveProficient { get; set; }
    }
