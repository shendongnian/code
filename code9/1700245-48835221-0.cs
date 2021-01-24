            if (string.IsNullOrWhiteSpace(name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movies = db.Movies.Where(x => x.Title.Contains(name)).ToList();
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View("index", movies);
        }
