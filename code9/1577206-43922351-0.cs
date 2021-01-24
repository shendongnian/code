    public async Task<IActionResult> RiceviListaSpesa([FromBody]List<Prova> ListaAcquisti)
    {
        var results = new List<YourResultType>();
        for (int i = 0; i < ListaAcquisti.Count; i++)
        {
            DateTime dt = Convert.ToDateTime(ListaAcquisti[i].Scadenza);
            var result = await _context.ProdottiMagazzino.SingleOrDefaultAsync(p => p.Prodotto.Codice == ListaAcquisti[i].Codice && p.Scadenza == dt);
            results.Add(result);
        } 
        // do whatever you need to all the results stored in results list
        return View();
    }
