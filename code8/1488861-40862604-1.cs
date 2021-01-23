    private void Form2_Load(object sender, EventArgs e)
    {
        IntPtr parentHandle = GetWindowLongPtr(this.Handle, GWL.GWL_HWNDPARENT);
        FormCollection fc = Application.OpenForms;
        foreach (Form frm in fc)
        {   
            if (frm.Handle==parentHandle)
            {
                Console.WriteLine(frm.Name); //this is your parent form
            }
                
        }
    }
