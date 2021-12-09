namespace Assesmet.Responses
{
    public class Response
    {
        public int Error { get; set; }
        public string Message { get; set; }
        public string ErrorDescription { get; set; }

        public Response Success()
        {
            return new Response() { Error = 0, Message = "Operación realizada con exito", ErrorDescription = string.Empty };
        }

        public Response Fail(string innerEx)
        {
            return new Response() { Error = 1, Message = "Fallo al realizar la operación", ErrorDescription = innerEx };
        }
    }
}