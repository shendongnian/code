    public Subject GetSubject()
    {
        return new SubjectProxy();
    }
    Subject subject = GetSubject();
    subject.Print(); // would use the proxied method
