    public class Foo
    {
       public int Id{get;set;}
       public string Test{get;set;}
    }
    private void GrdBind()
    {
        List<Foo> result = new List<Foo>(); //Foo is your class for item
        //...populate the list
        gv.DataSource = result;
        gv.Databind();
    }
