namespace ToDoListWebMVC.Services.Exceptions
{
    public class DbConcunrrencyException(string message) : ApplicationException(message)
    {
    }
}
