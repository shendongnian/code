    return db.GENERIC_INGREDIENTS
        .Where(genericIngredient => genericIngredient.STATUS_CODE_ID == enabledId)
        .AsEnumerable()
        .Select(genericIngredient => GenericIngredientToViewModelWithUnitLabel(genericIngredient, languageId))
        .Join(db.INGREDIENTS,
            gi => gi.Id,
            i => i.GENERIC_INGREDIENT_ID,
            (i, gi) => new { GENERIC_INGREDIENTS = gi, INGREDIENTS = i })
        .OrderBy(output => output.GENERIC_INGREDIENTS.Name)
