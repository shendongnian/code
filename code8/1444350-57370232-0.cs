        private MD5 _md5 = new MD5CryptoServiceProvider();
        private Dictionary<Type, XmlSerializer> _serializers = new Dictionary<Type, XmlSerializer>();
        public Guid CreateID(object obj)
        {
          if (obj == null) return Guid.Empty;
          var type = obj.GetType();
          if (!_serializers.TryGetValue(type, out var serializer))
          {
            serializer = new XmlSerializer(type);
            _serializers.Add(type, serializer);
          }
          using (var stream = new MemoryStream())
          {
             serializer.Serialize(stream, obj);
             stream.Position = 0;
             return new Guid(_md5.ComputeHash(stream));
          }
        }
