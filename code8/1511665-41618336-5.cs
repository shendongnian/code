public class ConsumerViewModel
{
    public ConsumerViewModel(Func&lt;Entity, EntityCRUDWindow&gt; entityCrudWindowFactory)
    {
       this.WhateverCommand = new DelegateCommand(
           () =>
           {
               Entity someEntity = null; //or whatever
               entityCrudWindowFactory(someEntity).ShowDialog();
           });
    }
    
    public ICommand WhateverCommand { get; }
}
