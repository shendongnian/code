        protected void Page_Load(object sender, EventArgs e)
        {
            //check for postback
            if (!IsPostBack)
            {
                //fill the dropdown
                DropDownListOfWeapon.DataSource = GetWeapons();
                DropDownListOfWeapon.DataTextField = "Name";
                DropDownListOfWeapon.DataValueField = "Id";
                DropDownListOfWeapon.DataBind();
                //add a select text at the first position
                DropDownListOfWeapon.Items.Insert(0, new ListItem("Select a weapon", "-1", true));
            }
        }
        private List<Weapon> GetWeapons()
        {
            //create a new list
            List<Weapon> weaponList = new List<Weapon>();
            //fill the list with dummy weapons
            //this probly would come from a database or other external source
            for (int i = 0; i < 10; i++)
            {
                Weapon weapon = new Weapon();
                weapon.Id = i;
                weapon.Name = "Weapon " + i;
                weapon.Attack = "Attack " + i;
                weapon.SortOfWeapon = "Sort of weapon " + i;
                weaponList.Add(weapon);
            }
            //sort the list alphabetically
            weaponList = weaponList.OrderBy(x => x.Name).ToList();
            return weaponList;
        }
        protected void DropDownListOfWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the id from the dropdown
            int Id = Convert.ToInt32(DropDownListOfWeapon.SelectedValue);
            if (Id < 0)
            {
                //clear the literal when no selection is made
                Literal1.Text = "";
            }
            else
            {
                //get the correct weapon from the list based on it's id using Linq
                List<Weapon> weaponList = GetWeapons().Where(x => x.Id == Id).ToList();
                //show the properties in the literal
                Weapon weapon = weaponList[0];
                Literal1.Text = weapon.Id + "<br />";
                Literal1.Text += weapon.Name + "<br />";
                Literal1.Text += weapon.Attack + "<br />";
                Literal1.Text += weapon.SortOfWeapon + "<br />";
            }
        }
        
        //the weapon class
        class Weapon
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Attack { get; set; }
            public string SortOfWeapon { get; set; }
        }
