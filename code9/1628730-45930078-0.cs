    <input type="submit" asp-page-handler="JoinList" value="Join" />
    <input type="submit" asp-page-handler="JoinListUC" value="JOIN UC" />
    
     public Customer Customer { get; set; }
    
            public async Task<IActionResult> OnPostJoinListAsync()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
    
                _db.Customers.Add(Customer);
                await _db.SaveChangesAsync();
                return RedirectToPage("/Index");
            }
    
            public async Task<IActionResult> OnPostJoinListUCAsync()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                Customer.Name = Customer.Name?.ToUpper();
                return await OnPostJoinListAsync();
            }
