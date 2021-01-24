    book => book.Publishers.Select(publisher => new
      {
        publisher.CreatedBy,
        publisher.DeletedBy
      });
