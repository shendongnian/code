    public static class FormExtension
      {
        public static CheckBox[] GetCheckboxes(this Form form)
        {
          return form.Controls.OfType<CheckBox>().ToArray();
        }
      }
