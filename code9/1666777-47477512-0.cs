    class Lesson : Entity
    {
        public virtual string Name { get; set; }
        public virtual Subject Subject { get; set; }
        public void ChangeSubject(Subject subject)
        {
            // do some checks
            Subject = subject;
        }
    }
    class Subject : Entity
    {
        public string Name { get; set; }
    }
    [Test]
    public void LessonChangeSubjectShouldNotAffectFormerSubjectPersistence()
    {
        var session = GetInMemorySession();
        // given
        Lesson exampleLesson = new Lesson { Name = "Lesson1", Subject = new Subject { Name = "Subject1" } };
        session.Save(exampleLesson.Subject);    // because we havent set cascade.save
        session.Save(exampleLesson);
        var formerSubjectId = exampleLesson.Subject.Id;
        // when
        Subject subject = new Subject { Name = "Subject2" };
        session.Save(subject);
        exampleLesson.ChangeSubject(subject);
        session.Flush();    // save all changes
        session.Clear();
        var formerSubject = session.Get<Subject>(formerSubjectId);
        subject = session.Get<Subject>(subject.Id);
        // then
        exampleLesson.Subject.Should().Be(subject);
        formerSubject.Should().NotBeNull();
        // technically not needed because the inmemory database is gone after this test
        session.Delete(formerSubject);
        session.Delete(subject);
    }
