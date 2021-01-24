      <input name="submit" type="submit" id="addText" value="Add" />
 
       public ActionResult Edit(ComicPanel comicPanel, string submit)
        {
            if(submit == "Add")
            {
                var newComicPanelText = new ComicPanelText();
                comicPanel.ComicPanelTexts.Add(newComicPanelText);
                db.Entry(newComicPanelText).State = EntityState.Added;
                db.Entry(comicPanel).State = EntityState.Modified; 
                db.SaveChanges();
                return View(comicPanel);
            }
