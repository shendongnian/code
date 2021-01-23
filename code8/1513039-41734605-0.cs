    public bool DeleteView(int viewId)
        {
            // This is a workaround. It seems ninject is not disposing the context. 
            // Because of that all the info (navigation properties) of a newly created view is presisted in the context.
            // Hence you get a referential key error when you try to delete a composite object.
            using (var context = new ApplicationDbContext())
            {
                var repo = new GenericRepository<CustomView>(context);
                var view = repo.GetById(viewId);
                repo.Delete(view);
                context.SaveChanges();
            }
            //var model = _unitOfWork.CustomViews.GetById(viewId);
            //_unitOfWork.CustomViews.Delete(model);
            //_unitOfWork.Save();
            return true;
        }
