namespace WebApi.Models
{
    public class Response<T>
    {
        public int StatusCode { get; set; }
        public T? Result {get;set;}

        public string Message = string.Empty;
    }

}