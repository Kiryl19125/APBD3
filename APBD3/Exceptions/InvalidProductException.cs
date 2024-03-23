namespace APBD3.Exceptions;

public class InvalidProductException : System.Exception
{
    public InvalidProductException()
    {
    }

    public InvalidProductException(string message) : base(message)
    {
    }

    public InvalidProductException(string message, System.Exception inner) : base(message, inner)
    {
    }
}