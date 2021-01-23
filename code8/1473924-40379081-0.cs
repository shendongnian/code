    public override bool Equals(object obj)
    {
                if (object.ReferenceEquals(this, obj))
                {
                    return true;
                }
                else
                {
                    ServiceId other = obj as ServiceId;
    
                    if (other == null)
                    {
                        return false;
                    }
                    else if (!(this.IsValid && other.IsValid))
                    {
                        return false;
                    }
                    else 
                    {
                        return this.UniqueId.Equals(other.UniqueId);
                    }
                }
    }
