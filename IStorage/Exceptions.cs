namespace admLab1.IStorage
{
    [System.Serializable]
    public class IncorrectVideoCardException : System.Exception
    {
        public IncorrectVideoCardException() { }
        public IncorrectVideoCardException(string message) : base(message) { }
        public IncorrectVideoCardException(string message, System.Exception inner) : base(message, inner) { }
        protected IncorrectVideoCardException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
