        List<MyClass> items = new List<MyClass>();
        for (int i = 0; i < ICOARPOST.Length; i++)
        {
            MyClass s = await _Services.Method(ICOARPOST[i].param1, ICOARPOST[i].param2);
            //no idea if this is how it works. might as well be s.Value != null or something similar
            if(s != null)
                items.add(s);
        }
        responcearrayPost = items.ToArray();
