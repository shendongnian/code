    public class SecondForm
    {
   
        private Person _SelectedPerson;
        public Person SelectedPerson
        {
            get { return _SelectedPerson; }
        }
        //Set data to the SelectedPerson in your click eventhandler
        private void metroButtonSelect_Click(object sender, EventArgs e)
        {
            _SelectedPerson = new Person();
            _SelectedPerson.No = metroGrid1.SelectedRows[0].Cells[0].Value.ToString();
            _SelectedPerson.Name = metroGrid1.SelectedRows[0].Cells[1].Value.ToString();
            _SelectedPerson.Address = metroGrid1.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
