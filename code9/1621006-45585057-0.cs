	public void RepeaterListato_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
	{
        IEnumerable<Immagini> immagini = null;
        switch (listType)
        {
		  case "pages":
			immagini = ((Pagina)e.Item.DataItem).Immagini;
            break;
		  case "schede":
			immagini = ((Scheda)e.Item.DataItem).Immagini;
            break;
		  case "news":
			immagini = ((New)e.Item.DataItem).Immagini;
            break;
        }
        if (immagini != null)
        {
          BuildFoto(e, immagini, IDCategoriaImmaginiPacchettoOfferta);
        }
	}
    private void BuildFoto(RepeaterItemEventArgs e, IEnumerable<Immagini> immagini, string id)
    {
        var immagine = immagini.Cast<Allegato>().Where(p => p.Categoria == id).FirstOrDefault();
        if (immagine != null)
        {
            // ...
        }
    }
