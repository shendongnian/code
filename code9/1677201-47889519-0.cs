       if (ModelState.IsValid)
        {
            nieuwsArtikel.blog = blog;
            nieuwsArtikel.blog.alineas = alineas;
            _context.Add(nieuwsArtikel);
            foreach (Aliena a in alienas)
            {
                _context.Add(a);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(nieuwsArtikel);
