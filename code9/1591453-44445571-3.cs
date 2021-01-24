    public class myItem
    {
        private void MyMethod(IMyClass parent)
        {
            int ParentClass_CodeProperty = parent.Code;
        }
    }
    //...
    //Initialization scope
    var _myItemToParentIndex = new Dictionary<myItem, IMyClass>();
    
    var item = new myItem();
    var cl = new myClass2();
    myClass2.Items.Add(item);
    _myItemToParentIndex.Add(item, myClass2);
    //...
    
    //Execution scope
    item.MyMethod(_myItemToParentIndex[item]);
