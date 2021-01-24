    using System.Drawing.Text;
    void mainformload(object sender, EventArgs s)
    {
        InstalledFontCollection inf=new      InstalledFontCollection();
        foreach(Font family font in inf.Families)
            combobox.Items.Add(font.Name); //filling the font name
        //get the font name of the rich text box text
        combobox.Text=this.richtextbox.Font.Name.ToString();
        }
    void comboboxselectionchanged(object sender, EventArgs e)
    {
        richtextbox.Font=new Font(comboboxselectionchanged.text, richtextbox.Font.Size);
    }
