    public abstract class BattleUnit {
        public abstract Type UnitType { get; }
    }
    public class BattleMonster : BattleUnit {
        /// <summary>
        /// Current type for this class.
        /// </summary>
        /// <remarks>Micro optimization instead of using this.GetType() or calling typeof(BattleMonster) each time.</remarks>
        static readonly Type Type = typeof(BattleMonster);
        
        public override Type UnitType => Type;
    }
    public class BattleUser : BattleUnit, IUser {
        /// <summary>
        /// Current type for this class.
        /// </summary>
        /// <remarks>Micro optimization instead of using this.GetType() or calling typeof(BattleUser) each time.</remarks>
        private static readonly Type Type = typeof(BattleUser);
        public override Type UnitType => Type;
    }
