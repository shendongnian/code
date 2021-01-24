    class BookRenderer
    {
        List<ISpecificBookRenderer> specificBookRenderers = ...; // pass via constructor
    
        public void RenderBook(Book b)
        {
            var matchingRenderer = specificBookRenderers.First(r => r.BookType == b.GetType());
            matchingRenderer.RenderBook(b);
        }
    }
