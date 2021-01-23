    public class Employee()
    {
       public int Code{get;set}
       public string Name{get;set;}
       public bool X {get{return Code == 0110300}}
       public static List<Employee> ReadAll(){//Get your data};
    }
    
    public class MyForm() : XtraForm
    {
       var data = Employee.ReadAll();
       gridControl.DataSource = data;
    
       //Access Employee code
       Employee emp = gridView.GetFocusedRow() as Employee;
       MessageBox.Show(emp.Code.ToString());
    }
