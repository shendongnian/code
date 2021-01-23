    IName IPerson_John=container.Resolve<IName>("John");
    IPerson_John.IntroduceYouself(); // "My name is john"
    
    IName IPerson_Larry= container.Resolve<IName>("Larry");
    IPerson_Larry.IntroduceYouself(); // "My name is Larry"
