using System.Text.Json.Serialization;

namespace Sat.Recruitment.Common.Web
{
    public class Result
    {
        public bool IsSuccess { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Errors { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Message { get; set; }

        public static Result Fail(string errors)
        {
            return new Result
            {
                IsSuccess = false,
                Errors = errors
            };
        }

        public static Result Success(string message)
        {
            return new Result
            {
                IsSuccess = true,
                Message = message
            };
        }
    }
}
