            foreach (var item in pictureList)
            {
                pictures pc = new pictures();
                //...
                pc.comments = new List<comments>();
                //linq to get comments here
                pc.comments.Add(new comments());
                pc.likes = new List<likes>();
                //linq to get likes
                pc.likes.Add(new likes());
                pictureList.Add(pc);
            };
