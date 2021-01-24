    public ActionResult DeleteConfirmed(int id)
    {
        foreach (var nota in local.notas)
        {
            var notaParaEliminar = db.NotasAdjuntas.find(nota.Id);
            db.NotasAdjuntas.Remove(notaParaEliminar);
        }
        Local local = db.Locales.Find(id);
        db.Locales.Remove(local);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
