            StyleDetail styleNew = new StyleDetail() { Id = "12", Code = "first" };
            StyleDetail styleOld = new StyleDetail() { Id = "23", Code = "second" };
            JsonPatchDocument<StyleDetail> pt = new JsonPatchDocument<StyleDetail>();
            pt.ApplyTo(styleOld);
            pt.Replace(st => st.Code, styleNew.Code);
            var serializedItemToUpdate = JsonConvert.SerializeObject(pt);
