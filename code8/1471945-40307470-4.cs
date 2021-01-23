    if (view == null) // otherwise create a new one
            {
                view = LayoutInflater.From(mcontext).Inflate(Resource.Layout.listview_Marks, null, false);
                holder = new ViewHolder();
                holder.comsevin = view.FindViewById<EditText>(Resource.Id.editTextTeacherMarks);
                holder.namenmn = view.FindViewById<TextView>(Resource.Id.textStudentNameTeacherMarks);
                holder.namenmn.Tag = position;//<------------here!!!
                view.Tag = holder;
            }
