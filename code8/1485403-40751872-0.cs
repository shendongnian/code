    this.Data = (
        from string line2D
        in data.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries)
        select new List<string>(    
          from string line
          in line2D.Split(new string[] { "^^" }, StringSplitOptions.RemoveEmptyEntries)
          select line.Split(';').ToArray());
