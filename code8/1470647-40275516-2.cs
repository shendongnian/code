     [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login([CustomizeValidator(RuleSet = "LoginRuleSet")] LoginRegisterViewModel model)
            { ...
            }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register([CustomizeValidator(RuleSet = "RegisterRuleSet")] LoginRegisterViewModel model)
            { ...
            }
    }
