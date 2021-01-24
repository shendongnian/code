    var answer = (from sch in context.schools
                  where sch.ID == 1
                  join st in context.students on sch.ID equals st.schoolID into subs
                  from sub in subs.DefaultIfEmpty()
                  group sub by new { sch.ID, sch.Name, sch.Location } into gr
                  select new 
                  {
                      gr.Key.Name,
                      gr.Key.Location,
                      Count = gr.Count(x => x != null)
                  }).First();
             
