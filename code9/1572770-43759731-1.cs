    public Form1 : Form
    {
      private Character Adventurer = null;
      public Form1()
      {
          Adventurer = new Character(.....); 
      }
        private void button1_Click(object sender, EventArgs e)
        {
            // here i would like to do something like this:
            Adventurer.Inventory.WeaponList.Add(new Weapon(...));
        }
