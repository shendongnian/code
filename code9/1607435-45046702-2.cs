    public abstract class Weapon
    {
        protected Weapon(WeaponCommandStrategy[] commandStrategies)
        {
            CommandStrategies = commandStrategies;
        }
        protected IEnumerable<WeaponCommandStrategy> CommandStrategies { get; }
        public void Use(WeaponCommand command)
        {
            var strategy = CommandStrategies.FirstOrDefault(c => c.Command == command);
            strategy?.Execute();
        }
    }
    public enum WeaponCommand
    {
        Fire,
        Swing,
        Reload
    }
    public abstract class WeaponCommandStrategy
    {
        public WeaponCommand Command { get; private set; }
        protected WeaponCommandStrategy(WeaponCommand command)
        {
            Command = command;
        }
        public abstract void Execute();
    }
