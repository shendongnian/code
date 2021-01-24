    public class ApiCall
    {
        private IEnumerable<Item> _result = null;
        private async Task<IEnumerable<Item>> A()
        {            
            if (_result == null)
            {
                _result = await C();
            }
    
            var items = _result;
            var myItems = items.Where(x => x.name == "my");
            return myItems;
        }
    
        //Method B
        private async Task<IEnumerable<Item>> B()
        {
            if (_result == null)
            {
                _result = await C();
            }
    
            var items = _result;
            var myItems = items.Where(x => x.name == "all");
            return myItems;
        }
    
        //Method C is await method
        private async Task<IEnumerable<Item>> C()    //appserver call
        {
            var itemsList = await Ioc.Resolve<IServiceCall>().InvokeAsync<IManager, ResultList>(this.MakeWeakFunc<IManager, ResultList>((service) => service.GetCounts()));
            return itemsList;
        }
    }
