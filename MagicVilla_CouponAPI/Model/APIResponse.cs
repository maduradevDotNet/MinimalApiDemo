using System.Net;

namespace MagicVilla_CouponAPI.Model
{
    public class APIResponse
    {
        public APIResponse() {
            ErrorMessages=new List<string>();
        }

        public Boolean isSuccess { get; set; }
        public object Result {  get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public List<string> ErrorMessages { get; set; }
    }
}
