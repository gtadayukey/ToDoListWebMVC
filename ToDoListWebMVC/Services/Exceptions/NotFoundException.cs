namespace ToDoListWebMVC.Services.Exceptions
{
    public class NotFoundException(string message) : ApplicationException(message)
    {
    }
}
