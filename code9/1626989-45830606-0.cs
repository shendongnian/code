    class FormFacotry
    {
    //Key is user level and value is Form.
    Dictionary<int,Form> formTable=new Dictionary<string,Form>();
    
    static FormFacotry()
    {
    //Prepare relation between user level and Form.
    formTable.Add(1,new Form1());
    formTable.Add(2,new Form2());
    }
    public Form GetForm(int userlevel,...)
    {
    return formTable[userleval];
    }
    }
