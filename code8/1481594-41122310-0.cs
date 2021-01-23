            public User GetUser(int id)
            {
              User usr = null;
              using (Context db = new Context())
              {
                  usr = db.Users.Find(id);
              }
              return usr;
             }
