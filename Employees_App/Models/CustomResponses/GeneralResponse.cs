namespace Employees_App.Models.CustomResponses
{
    public class GeneralResponse
    {
        public bool Result { get; set; }
        public List<object> Data { get; set; }
        public string Message { get; set; }
    }
    public class ApiResponse<T>
    {
        public string Status { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
