    public async Task Method1() {
        while (statement1) {
            ~code~
            await Method2(i);
        }
        while (statement2) {
            ~code~
            await Method2(i);
        }
    }
    public async Task Method2(int i) {
        if(statement){
            ~code~
            await Task.Delay(2000);
        }
        else
        {
            ~code~
            await Task.Delay(2000);
        }
    }
