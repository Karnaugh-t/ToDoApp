namespace ToDoApp.common
{
    public abstract class  GenericResponse
    {
        public string message { get; set; } = null!;
        public string token { get; set; } = null!;

        public enum Code : ushort
        {
            Error = 0,
            Success = 1,
            Unauthorized = 3
        }

        public Code Codes { get; set; }
        public bool status { get; set; } = false;
    }
}
