	var all = allQuiz.ToList();
	all.AddRange(allExam.ToList());
	all.AddRange(allExc.ToList());
	var result = all.GroupBy(x => new { x.Date, x.Subj })
                    .Select(x => new { x.Key.Date, x.Key.Subj, Sum = x.Sum(s => s.Sum) });
	var list = result.GroupBy(r => r.Date).Select(x => new {Date = x.Key, 
	       Math = x.SingleOrDefault(t=>t.Subj==1)?.Sum??0,
		   Science = x.SingleOrDefault(t=>t.Subj==2)?.Sum??0,
		   History = x.SingleOrDefault(t=>t.Subj==3)?.Sum??0,
		   Language = x.SingleOrDefault(t=>t.Subj==4)?.Sum??0,
		   });
