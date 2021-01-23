    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Inheritance.Classes
    {
        public class Controller<T, U> where T : Model, new() where U : View, new()
        {
            protected T _model;
            protected U _view;
    
            public Controller()
            {
                this._model = new T();
                this._view = new U();
            }
    
            public Controller(T model, U view)
            {
                this._model = model;
                this._view = view;
            }
    
            public string ParentFunction()
            {
                return "I'm the parent";
            }
        }
    }
