    public dynamic OptionalPredicate
            {
                get
                {
                    if (this.ViewState[this.ClientID + "OptionalPredicate"] != null)
                    {
                        var expressionSerializer = new Serialize.Linq.Serializers.ExpressionSerializer(new Serialize.Linq.Serializers.XmlSerializer());
                        return expressionSerializer.DeserializeText(this.ViewState[this.ClientID + "OptionalPredicate"].ToString()) as dynamic;   
                    }
                    else
                    {
                        return default(dynamic);
                    }
                }
                set
                {
                    var expressionSerializer = new Serialize.Linq.Serializers.ExpressionSerializer(new Serialize.Linq.Serializers.XmlSerializer());
                    this.ViewState[this.ClientID + "OptionalPredicate"] = expressionSerializer.SerializeText(value);
                }
            }
