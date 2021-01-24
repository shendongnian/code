            DynamicDictionary dynamicDictionary = ToDynamicDictionary(dictionary);
            return this
              .Negotiate
              .WithModel(dynamicDictionary)
              .WithStatusCode(HttpStatusCode.OK);
