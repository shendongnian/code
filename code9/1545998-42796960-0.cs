            // You add tool strip menu items like this
            ToolStripMenuItem tsmiAttack = new ToolStripMenuItem("Attack");
            m_combatOptions.Items.Add(tsmiAttack);
            ToolStripMenuItem tsmiMagic = new ToolStripMenuItem("Magic");
            m_combatOptions.Items.Add(tsmiMagic);
            ToolStripMenuItem tsmiDefend = new ToolStripMenuItem("Defend");
            m_combatOptions.Items.Add(tsmiDefend);
            // Now you can add other tool strip menu items
            ToolStripMenuItem tsmiFireball = new ToolStripMenuItem("Fireball, 10 MP");
            tsmiMagic.DropDownItems.Add(tsmiFireball);
            ToolStripMenuItem tsmiHeal = new ToolStripMenuItem("Heal, 15 MP");
            tsmiMagic.DropDownItems.Add(tsmiHeal);
            // And your final targets
            ToolStripItem tsiTargetA = tsmiFireball.DropDownItems.Add("Target A: Goblin");
            // Now add your click event hanlder
            tsiTargetA.Click += (s, e) => Fireball(0);
