    public ActionResult DeleteConfirmed(int id)
    {
        _userRepository.Delete(id);
        _userRepository.Save();
        return RedirectToAction("Index", "Admin");
    }
    <% using (Html.BeginForm("DeleteConfirmed", "User"))
    { %>
    <input name="id" value="1"/>
    <input type='submit' value='Delete' />
    <% } %>
