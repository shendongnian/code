    public static void UseAndSave<TResult>(
       Action<Context> pAction
    ) {
       using (var context = new Context()) {
          pAction(context);
          context.SaveChanges();
       }
    }
    ...
    Context.UseAndSave(context => context.Users.Add(user));
