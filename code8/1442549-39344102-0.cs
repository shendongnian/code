     if (bc.Length > 0)
                {
                    for(int i = 0; i < bc.Length; i++)
                    {
                        string x = bc[i].objectClass.value.ToString();
                        if (bc[i].objectClass.value.ToString().Equals("group"))
                        {
                            group gp = (group)bc[i];
                            baseClass[] members = gp.members.value;
                            if(members != null && members.Length > 0)
                            {
                                for(int j = 0; j < members.Length; j++)
                                {
    
                                        output.AppendFormat("Members:  {0}\n", gp.members.value[j].searchPath.value); 
                                        output.AppendFormat("DefaultName: {0}\n\n", gp.defaultName.value);
                                }
                            }
                        }
                    }
                }
