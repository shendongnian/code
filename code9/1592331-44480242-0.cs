        public interface ISlot<out TType>
        {
            TType Slot { get; }
        }
        public class BaseClass
        {
        }
        public class DungeonInventorySlot : BaseClass, ISlot<DungeonInventorySlot>
        {
            DungeonInventorySlot ISlot<DungeonInventorySlot>.Slot
            {
                get { return this; }
            }
        }
        public class ActiveSkillSlot : BaseClass, ISlot<ActiveSkillSlot>
        {
            ActiveSkillSlot ISlot<ActiveSkillSlot>.Slot
            {
                get { return this; }
            }
        }
        public class BattleFlow
        {
            public ISlot<BaseClass> HoldSlot;
        }
        private void Test()
        {
            var s = new BattleFlow();
            s.HoldSlot = new ActiveSkillSlot();
            s.HoldSlot = new DungeonInventorySlot();
        }
