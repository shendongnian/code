    public IActionResult OnPost(decimal Money, int Age)
    {
        if (!ModelState.IsValid)
        {
            //ModelState invalid, todo here (e.g. handling)
        }
        this.Money = Money;
        this.Age = Age;
        return Page();
    }
