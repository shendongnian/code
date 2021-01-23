    using (var enumerator = _shuffledClasses.Where(entry => entry.Key.Name.Equals(originName))
                                .Where(entry => entry.Key.Namespace.Equals(type.Namespace))
                                .Select(item => item.Value).GetEnumerator()) {
        enumerator.MoveNext(); // maybe check here if the operation is successful!
        type.Name = enumerator.Current.Name;
    }
