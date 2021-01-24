    public class Page2 : SomeParentClass
    {
       ...
       // add your XMLData property
       public XMLData.MyRootElement mre { get; set; }
       ...
       // the constructor
       public Page2(XMLData.MyRootElement data){
           // Save the user data in xmldat property. So this data could be reused later.
           this.mre = data;
       }
    }
