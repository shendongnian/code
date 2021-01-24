        public virtual int Delete(List<object> ids, string userName)
        {
            try
            {
                foreach (var id in ids)
                {
                    var dbObject = _table.Find(id);
                    HistroyBaseModel historyRecord = null;
                    var modelAssembly = Assembly.Load(nameof(ProductVersionModel));
                    var historyType =
                        modelAssembly.GetType(
                            // ReSharper disable once RedundantNameQualifier   - dont remove namespace it is required
                            $"{typeof(ProductVersionModel.Model.History.HistroyBaseModel).Namespace}.{typeof(TModel).Name}History");
                    if (historyType != null)
                    {
                        var historyObject = Activator.CreateInstance(historyType);
                        historyRecord = MapDeletingObjectToHistoyObject(dbObject, historyObject, userName);
                        DatabaseContext.Entry(historyRecord).State = EntityState.Added;
                    }
                    DatabaseContext.Entry(dbObject).State = EntityState.Deleted;
                }
                return DatabaseContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw HandleDbException(ex);
            }
        }
        protected virtual HistroyBaseModel MapDeletingObjectToHistoyObject(object inputObject, object outputObject, string userName)
        {
            var historyRecord = MapObjectToObject(inputObject, outputObject) as HistroyBaseModel;
            if (historyRecord != null)
            {
                historyRecord.DeletedBy = userName;
                historyRecord.DeletedTime = DateTime.UtcNow;
            }
            return historyRecord;
        }
        protected virtual object MapObjectToObject(object inputObject, object outputObject)
        {
            var inputProperties = inputObject.GetType().GetProperties();
            var outputProperties = outputObject.GetType().GetProperties();//.Where(x => !x.HasAttribute<IgnoreMappingAttribute>());
            outputProperties.ForEach(x =>
            {
                var prop =
                    inputProperties.FirstOrDefault(y => y.Name.Equals(x.Name) && y.PropertyType == x.PropertyType);
                if (prop != null)
                    x.SetValue(outputObject, prop.GetValue(inputObject));
            });
            return outputObject;
        }
