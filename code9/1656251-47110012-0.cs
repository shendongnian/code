    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace StackOverflow
    {
        public partial class FormMain : Form
        {
            public FormMain()
            {
                InitializeComponent();
            }
        }
    
        public partial class ImageButton : Button
        {
            //Override OnClick event.
            protected override void OnClick(EventArgs e)
            {
                /*
                  "Unselect" every ImageButton that belongs to the 
                  same group as  the current ImageButton and 
                  select the current one.
                */
                do
                {
                    /*
                        Change Image of current ImageButton. 
                        I'm changing the BackColor for simplicity. You have to remove this line.
                    */
                    this.BackColor = System.Drawing.Color.Green;
                    //this.BackgroundImage = 1m.png;
    
                    //If ImageButton parent is null, then it doesn't belong in a group.
                    if (this.Parent == null)
                        break;
    
                    /*
                        Else loop through all other ImageButtons of the same group and clear them. 
                        Include System.Linq for this part.
                    */
                    foreach (ImageButton button in this.Parent.Controls.OfType<ImageButton>())
                    {
                        //If button equals to current ImageButton, continue to the next ImageButton.
                        if (button == this)
                            continue;
    
                        //Else change the Image.
                        button.BackColor = System.Drawing.Color.Red;
                        //this.BackgroundImage = 2m.png;
                    }
                }
                while (false);
    
                //Continue with the regural OnClick event.
                base.OnClick(e);
            }
        }
    }
