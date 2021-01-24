    IEnumerator getData () {
        List<string> sqlResults;
        var thread = new System.Threading.Thread(() => {
            sqlResults = Database.query("SELECT * FROM table");
        };
        thread.Start();
        while(thread.IsAlive){
            yield return null;
        }
        updateMenu();
    }
