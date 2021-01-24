        // This defines the "monopoly cards"
        // Community Chest cards give or take money, so we'll expect an int to be returned 
        public delegate int CommunityChestCard();
        // Chance cards just do things without any return values
        public delegate void ChanceCard();
        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Tag = new ChanceCard(GoDirectlyToJail);
            checkBox2.Tag = new ChanceCard(AdvanceToGo);
            checkBox3.Tag = new CommunityChestCard(WinBeautyContest);
            checkBox4.Tag = new CommunityChestCard(PayDoctorsFees);
        }
        private void GoDirectlyToJail()
        {
            MessageBox.Show("You went to jail!");
        }
        private void AdvanceToGo()
        {
            MessageBox.Show("You advanced to Go!");
        }
        private int WinBeautyContest()
        {
            MessageBox.Show("You won $20 in a beauty contest!");
            return 20;
        }
        private int PayDoctorsFees()
        {
            MessageBox.Show("You had to pay $50 in doctor's fees!");
            return -50;
        }
        // Now when we click the button, we'll loop through our checkboxes, 
        // see which ones were checked, and then execute the methods defined
        // in the associated chance/communitychest cards.
        private void button1_Click(object sender, EventArgs e)
        {
            // this.Controls is a collection of the child controls on the current form
            foreach(Control ctl in this.Controls)
            {
                // See if the control is a CheckBox
                if(ctl is CheckBox)
                {
                    // It is - let's cast it for easier coding...
                    CheckBox chk = (CheckBox)ctl;
                    // Is it checked?
                    if (chk.Checked)
                    {
                        // Yep! Does it have a value in its Tag?
                        if (chk.Tag != null)
                        {
                            if(chk.Tag is CommunityChestCard)
                            {
                                CommunityChestCard ccCard = (CommunityChestCard)chk.Tag;
                                // Call the function on the card and get the result
                                int adjustMoneyByAmount = ccCard();
                            }
                            else if(chk.Tag is ChanceCard)
                            {
                                ChanceCard cCard = (ChanceCard)chk.Tag;
                                // Call the function on the card
                                cCard();
                            }
                        }
                    }
                }
            }
        }
