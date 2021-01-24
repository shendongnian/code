    //using System;
    //using System.Linq;
    //using System.Collections.Generic;
	List<Func<int,int,bool>> useCases = new List<Func<int,int,bool>>
    {
        (age, switchFinal) =>  switchFinal < 20 && age >= 17 && age < 21,
        (age, switchFinal) =>  switchFinal < 22 && age >= 17 && age < 28,
        (age, switchFinal) =>  switchFinal < 24 && age >= 28 && age < 40,
        (age, switchFinal) =>  switchFinal < 24 && age >= 40
    };
    public bool IsEligble(int age, int switchFinal)
    {
        return useCases.Where
        (
            func => func(age, switchFinal)
        )
        .Any();
    }
