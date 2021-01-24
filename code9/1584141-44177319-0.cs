            dynamic product1 = new ExpandoObject();
            product1.Name = "Name1";
            product1.Search = "Search1";
            productList.Add(product1);
            dynamic product2 = new ExpandoObject();
            product2.Name = "Name2";
            product2.Search = "Search2";
            productList.Add(product2);
            dynamic product3 = new ExpandoObject();
            product3.Name = "Name3";
            product3.Search = "Search3";
            productList.Add(product3);
            TestClass obj = new TestClass();
            obj.Property1 = "p1";
            obj.Property2 = "p2";
            obj.Property3 = "p3";
            obj.Property4 = "p4";
            obj.ProductList = productList;
            XmlSerializer xmlSerializeraa = new XmlSerializer(obj.GetType());
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializeraa.Serialize(textWriter, obj);
                string xmlStringOut = textWriter.ToString();
                Console.WriteLine(textWriter);
            }
