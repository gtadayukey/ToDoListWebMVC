namespace ToDoListWebMVC.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public string? ErrorMessage { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
