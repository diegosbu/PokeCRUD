namespace Poke_CRUD_App.Models {
    public class LoginRegisterViewModel {
        public string SubmitAction { get; set; }

        public string LinkAction { get; set; }

        public string Title { get; set; }

        public string LinkPrompt { get; set; }

        public string SubmitPrompt { get; set; }

        public LoginRegisterViewModel(string submitAction, string linkAction, string title, string linkPrompt, string submitPrompt) {
            SubmitAction = submitAction;
            LinkAction = linkAction;
            Title = title;
            LinkPrompt = linkPrompt;
            SubmitPrompt = submitPrompt;
        }
    }
}
