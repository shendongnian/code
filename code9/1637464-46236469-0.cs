        public void AssignValue(MyBaseClass entity)
        {
            var item = this.GetType().GetFields().FirstOrDefault(x => x.FieldType == entity.GetType());
            if (item != null)
            {
                item.SetValue(this, entity);
            }
        }
