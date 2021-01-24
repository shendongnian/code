    public bool Remove(string name)
    {
      this.CheckHeaderName(name);
      if (this.headerStore == null)
        return false;
      return this.headerStore.Remove(name);
    }
