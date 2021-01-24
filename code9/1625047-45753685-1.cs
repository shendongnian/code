    public IActionResult Sheet(Guid characterId) {
        var character = _repository.GetCharacter(characterId);
        // omit validation for brevity
        return View("Sheet", _viewModelFactory.Create(character, true, true));
    }
