    List<Post> x;
    public HomePage(){
      GetList()
    }
    
    public async Task GetList(){
      x = await GetTodoItemsAsync();
    }
