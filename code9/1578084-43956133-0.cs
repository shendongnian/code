       var styles = new Dictionary<string, AttackStyle>();
       styles.Add("Jump", new AttackStyle() 
                          {
                               Name = "Attack Achilles",
                               ParameterID = 0,
                               Forward = Vector3.forward,
                               HorizontalFOA = 70f,
                               VerticalFOA = 40f,
                               DamageModifier = 1f,
                               ActionStyleAlias = "Jump",
                               IsInterruptible = true
                          });
