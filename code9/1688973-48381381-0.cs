    public GameAttributes ()
            {
                dynamic expando = new ExpandoObject();
                this.Attribute = expando as IDictionary<string,string>;
            }
