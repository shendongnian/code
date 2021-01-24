    using System.Linq;
    //Set three specific controls
    new[]{myControl1, myControl2, myControl2}.ToList().ForEach(a => {a.Text = "Test";  a.BackColor = Color.Red; a.MultiLine = true});
    //Set all controls
    this.Controls.ToList().ForEach(a => {a.Text = "Test";  a.BackColor = Color.Red; a.MultiLine = true});
