    using (HttpClient httpClient = new HttpClient()) {
        var users = JsonConvert.DeserializeObject<List<User>>(
                        await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/posts")
                    );
        var todos = JsonConvert.DeserializeObject<List<UserToDoList>>(
                await httpClient.GetStringAsync("http://jsonplaceholder.typicode.com/todos")
            );
        var result = from user in users
                     join todo in todos on user.UserId equals todo.UserId into userTodos
                     select new { UserId = user.UserId, Name = user.Name, CountOfTodos = userTodos.Count() };
    }
