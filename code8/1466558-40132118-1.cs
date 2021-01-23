    var genders = new Gender
    {
        GenderListWrap = new List<GenderListWrap>
        {
            new GenderListWrap
            {
                GenderList = new List<Item>
                {
                    new Item { Code = "F", Description = "Female" },
                    new Item { Code = "M", Description = "Male" },
                }
            },
            new GenderListWrap
            {
                GenderList = new List<Item>
                {
                    new Item { Code = "N", Description = "Neutral" },
                }
            }
        }
    };
    var genderList = genders.GenderListWrap.SelectMany(l => l.GenderList).ToList();
