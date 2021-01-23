        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is UserTextCommand)
            {
                return User_Text_Message;
            }
            else if (item is AnastasiaTextAnswer)
            { 
                return Anastasia_Text_Message;
            }
            else
            {
                return null;
            }
        }
