    public abstract class Ability
    {
        public Entity Owner;
        public Entity Target;
        public Ability(Entity owner = null)
        {
            Owner = owner;
        }
        protected abstract void Do();
        /* Other Methods */
    }
    public abstract class AuraAbility : Ability
    {
        private readonly Func<Entity, Entity, Aura> auraFactory;
        protected AuraAbility(Entity owner, 
            Func<Entity, Entity, Aura> auraFactory) 
            : base(owner)
        {
            this.auraFactory = auraFactory;
        }
        protected override void Do()
        {
            Target.AddAura(auraFactory(Owner, Target));
        }
    }
    public class Attune : AuraAbility
    {
        public Attune(Entity owner = null)
            : base(owner, (o, target) => new SpecifiedAura(o, target))
        {
        }
    }
