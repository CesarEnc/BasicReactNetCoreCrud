namespace Persons.Api.Exceptions
{
    public class MailInUseException : Exception
    {
        public MailInUseException()
        {
        }

        public MailInUseException(string message)
            : base(message)
        {
        }

        public MailInUseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
