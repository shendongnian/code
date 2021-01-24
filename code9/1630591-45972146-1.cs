    public void LoadMoney()
    {
        String money = System.IO.File.ReadAllText(filename).Trim(); //trim removes all whitespace at the beginning and the end. May not be needed, but I personally do it just in case.
        if (int.TryParse(line, out MainForm.Money))
        {
            //MainForm.Money will already be set to the correct value here. You probably only need to check if it doesnt parse, and then handle that case.
        }
    }
