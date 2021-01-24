    public partial class Form1 : Form
    {
        private double CurrentMana { get; set; } = 50;
        private List<BasicSpell> m_lstSpells = new List<BasicSpell>();
        private List<BasicTarget> m_lstTargets = new List<BasicTarget>();
        
        public Form1()
        {
            InitializeComponent();
            Init();
            try
            {
                ToolStripMenuItem tsmiMagic = new ToolStripMenuItem("Magic");
                foreach (BasicSpell spell in m_lstSpells)
                {
                    ToolStripMenuItem tsmiSpell = spell.ToToolStripMenuItem();
                    if (spell.CanHitAllEnemies)
                    {
                        ToolStripItem tsiAll = tsmiSpell.DropDownItems.Add("All");
                        tsiAll.Click += (sender, arguments) => m_lstTargets.ForEach((target) => TryCastSpell(spell, target));
                    }
                    else { } // This spell can not hit all enemies
                    for (int i = 0; i < m_lstTargets.Count; i++)
                    {
                        BasicTarget target = m_lstTargets[i];
                        ToolStripItem tsiTarget = tsmiSpell.DropDownItems.Add($"Target {i}: {target.Name}");
                        tsiTarget.Image = target.StatusImage;
                        tsiTarget.Click += (sender, arguments) => TryCastSpell(spell, target);
                    }
                    tsmiMagic.DropDownItems.Add(tsmiSpell);
                }
                m_tsCombatOptions.Items.Add(tsmiMagic);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
        private void TryCastSpell(BasicSpell spell, BasicTarget target)
        {
            if (!spell.Cast(target))
            {
                MessageBox.Show($"You can not cast this spell with your current mana!");
            }
        }
        private void Init()
        {
            m_lstSpells.Add(new Fireball());
            m_lstSpells.Add(new Fireball());
            m_lstSpells.Add(new Fireball());
            m_lstSpells.Add(new Fireball());
            m_lstTargets.Add(new Monster("Reißzahn", 500));
            m_lstTargets.Add(new Monster("Reißzahn", 500));
            m_lstTargets.Add(new Monster("Reißzahn", 500));
            m_lstTargets.Add(new Monster("Reißzahn", 500));
            m_lstTargets.Add(new Monster("Reißzahn", 500));
        }
    }
    // TODO: POWER?
    [Flags]
    public enum Element
    {
        Fire = 0x0,
        Earth = 0x1,
        Water = 0x2,
        Wind = 0x4
    }
    public abstract class BasicSpell
    {
        public string Name { get; set; }
        public Element DamageType { get; set; }
        public double ManaCost { get; set; }
        public bool CanHitAllEnemies { get; set; } = false;
        public abstract bool Cast(BasicTarget target);
        public ToolStripMenuItem ToToolStripMenuItem()
        {
            ToolStripMenuItem tsmiSpell = new ToolStripMenuItem();
            tsmiSpell.Text = $"{this.Name}, {ManaCost} MP";
            return tsmiSpell;
        }
    }
    public class Fireball : BasicSpell
    {
        public override bool Cast(BasicTarget target)
        {
            // TODO: Check if castable (maybe add caster as parameter)
            target.HP -= 500;
            return true;
        }
    }
    public abstract class BasicTarget
    {
        public enum CombatStatus
        {
            Alive = 0,
            Dead = 1
        }
        public enum TargetRelation
        {
            Enemy = 0,
            Ally = 1
        }
        public string Name { get; set; }
        public double HP { get; set; }
        public CombatStatus Status { get; set; }
        public TargetRelation Relation { get; set; }
        public Image StatusImage => null;
    }
    public class Monster : BasicTarget
    {
        public Monster(string strName, int nHP)
        {
            this.Name = strName;
            this.HP = nHP;
            this.Status = CombatStatus.Alive;
            this.Relation = TargetRelation.Enemy;
        }
    }
