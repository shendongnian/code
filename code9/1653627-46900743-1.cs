    public ViewResult viewAllPagar(int? page, DateTime? dtIni, DateTime? dtFim)
    {
         // other stuff
    
         SearchContaPagarReceberModel model = new SearchContaPagarReceberModel();
         try 
         {
                // other stuff
    
                // assign IPagedList interface property
                model.lista = _listaModel.ToPagedList(pagina, 50);
    
                // add the IPagedList content to viewmodel list
                model.ContaPagarReceberModels = model.lista.ToList();
    
                // other stuff
         } 
         catch (Exception e)
         {
             Debug.WriteLine("Erro viewAllPagar ContasPagRecController" + e.Message);
         }
    
         return View(model);
    }
