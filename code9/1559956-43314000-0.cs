        public int Attribute(string name)
        {
            return _attributes.ContainsKey(name) ? _attributes[name].Address : -1;
        }
    
        public int Uniform(string name)
        {
            return _uniforms.ContainsKey("name") ? _uniforms[name].Address : -1;
        }
        public uint Buffer(string name)
        {
            return _buffers.ContainsKey(name) ? _buffers[name] : 0;
        }
