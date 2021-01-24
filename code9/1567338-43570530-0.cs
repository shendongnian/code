    var data = models.GroupBy(item => item.Key.Substring(0, item.Key.IndexOf(".")))
          .Select(group => group.Aggregate(new User(), (user, item) =>
          {
              PropertyInfo propertyInfo = user.GetType().GetProperty(item.Key.Substring(item.Key.IndexOf(".") + 1));
              propertyInfo.SetValue(user, Convert.ChangeType(item.Value, propertyInfo.PropertyType), null);
              return user;
          })).ToList();
