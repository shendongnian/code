    abstract class BusinessObject : ObservableObject, IBusinessObject { }
    class ObservableObject { }
    interface IBusinessObject { }
    abstract class BusinessModel<T> : IBusinessModel<T> where T : IBusinessObject { }
    interface IBusinessModel<out T> { } //This change should be made as suggested in my answer
    class User : BusinessObject { }
    class UserModel : BusinessModel<User> { }
