    using (LibraryContext ctx = new LibraryContext())
    {
        Usuario u = (Usuario)Session["usuario"];
        ViewBag.LivroId = new SelectList(db.Livro.Where(c => c.UsuarioId == u.UsuarioId), "LivroId", "Titulo");
        return View(emprestimo);
    }
