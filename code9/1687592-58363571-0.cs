        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
             var index = int.Parse(item.ToString());
             switch(index)
             {
                 case 0:
                     return MatchEventsTemplate;
                 case 1:
                     return CommentsTemplate;
             }
             throw new Exception($"The template {index} isn't implemented")
        }
