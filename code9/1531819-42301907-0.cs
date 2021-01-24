            int i = 0;
            while (reader.Read())
            {
                Button btn = new Button();
                string name = reader["name"].ToString();
                btn.Text = name;
                btn.Name = "desk_" + reader["id"];
                btn.Size = new Size(100, 60);
                btn.Location=new Point(100, 100+i);
                desk.Add(btn);
                i += 10;
            }
