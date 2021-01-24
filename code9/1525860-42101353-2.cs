    public IList<Mail> GetMails()
    {
        return _context.Mails.Include(m => m.Files).ToList();
    }
    
    public Mail GetMailById(int id)
    {
        return _context.Mails.Include(m => m.Files).SingleOrDefault(m => m.MailId == id);
    }
