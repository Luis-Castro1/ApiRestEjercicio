namespace ApiLuisEjercicio2.Response
{
    public class PersonaResponse
    {

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

        public PersonaResponse()
        {
            Message = string.Empty;
            Result = new object();
        }
    }
}
