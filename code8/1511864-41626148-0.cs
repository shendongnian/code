    var p = from c in db.Paragraps
                    where c.ArticleID == id
                    select c;
            ParToDelete.AddRange(p);
            var Test = db.Pictures.ToList();
            foreach (var item in p)
            {
                foreach(var obj in Test)
                    if(item.ID == obj.ID)
                          PicToDelete(obj);
            }
            foreach (var item in article.Ingreadient)
            {
                IngToDelete.Add(item);
            }
            db.Paragraps.RemoveRange(ParToDelete);
            db.Pictures.RemoveRange(PicToDelete);
            db.Articles.Remove(article);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
