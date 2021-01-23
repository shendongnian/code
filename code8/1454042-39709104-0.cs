      new Dish
          {
            Name ="Uthapizza", Image="~/Images/uthapizza.png", Category="Mains",
            Label ="Hot", Price=4.99, Description="dish comments" ,
            Comments = new List<Comment>()
                   {
                     new Comment { Rating = 5, Author = "John Lemon",
                                  Comments = "author comments",
                                  DatePosted = DateTime.Parse("2012-10-16T17:57:28.556094Z")
                    },
                    new Comment { Rating = 4, Author = "Paul McVites",
                                 Comments = "author comments",
                                 DatePosted = DateTime.Parse("2014-09-05T17:57:28.556094Z")
                    },
                    new Comment { Rating = 3, Author = "Michael Jaikishan",
                                 Comments = "Eat it, just eat it!",   DatePosted = DateTime.Parse("2015-02-13T17:57:28.556094Z")
                     },
        
                  }
             },
