        public async Task<List<YourDtoType>> GetConfig(string section, string group, string name)
        {
            var configurations = await _repository.GetConfig(section, group, name);
            return configurations.ToList();
        }
