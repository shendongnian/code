    public class Account
    {
    	public string AccountName { get; set; }
    	public string CustomerName { get; set; }
    }
    
    public class Card
    {
    	public string CardName { get; set; }
    	public string AccountName { get; set; }
    }
    
    public List<Account> Accounts { get; set; }
    public List<Card> Cards { get; set; }
    
    //OLD
    public async Task<string[]> FindAccounts(string customer)
    {
    	return await Task.Run(() =>
    	{
    		return Accounts.Where(a => a.CustomerName == customer).Select(a => a.AccountName).ToArray();
    	});
    }
    
    //OLD
    public async Task<string[]> FindCards(string[] accounts)
    {
    	return await Task.Run(() =>
    	{
    		return Cards.Where(c => accounts.Contains(c.AccountName)).Select(a => a.CardName).ToArray();
    	});
    }
    
    //NEW
    public async Task<string[]> FindCards(Task<string[]> findAccountsTasks)
    {
    	return await Task.Run(async () =>
    	{
    		var accounts = await findAccountsTasks;
    		return Cards.Where(c => accounts.Contains(c.AccountName)).Select(a => a.CardName).ToArray();
    	});
    }
    
    //NEW
    public async Task<string[]> FindCards(string customer)
    {
    	return await await FindAccounts(customer).ContinueWith(FindCards);
    }
    
    private async void button7_Click(object sender, EventArgs e)
    {
    	Accounts = new List<Account>
    	{
    		new Account {CustomerName = "Tomas", AccountName = "TomasAccount1"},
    		new Account {CustomerName = "Tomas", AccountName = "TomasAccount2"},
    		new Account {CustomerName = "Tomas", AccountName = "TomasAccount3"},
    		new Account {CustomerName = "John", AccountName = "JohnAccount1"}
    	};
    
    	Cards = new List<Card>
    	{
    		new Card {AccountName = "TomasAccount1", CardName = "TomasAccount1Card1"},
    		new Card {AccountName = "TomasAccount1", CardName = "TomasAccount1Card2"},
    		new Card {AccountName = "TomasAccount1", CardName = "TomasAccount1Card3"},
    		new Card {AccountName = "TomasAccount1", CardName = "TomasAccount2Card1"},
    		new Card {AccountName = "JohnAccount1", CardName = "JohnAccount1Card1"},
    		new Card {AccountName = "JohnAccount1", CardName = "JohnAccount1Card2"},
    	};
    
    	var customers = new List<string> { "Tomas", "John" }.ToArray();
    
    	//OLD
    	var accountstasks = customers.Select(FindAccounts);
    	var accounts = await Task.WhenAll(accountstasks);
    
    	var cardTasks = accounts.Select(FindCards);
    	var cards = await Task.WhenAll(cardTasks);
    
    	//NEW
    	cardTasks = customers.Select(FindCards);
    	cards = await Task.WhenAll(cardTasks);
    }
