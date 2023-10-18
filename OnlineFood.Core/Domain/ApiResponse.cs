using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFood.Core.Domain
{
    public class ApiResponse<T>
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(HttpStatusCode _Code, string _Message, T _Data)
        {
            Code = _Code;
            Message = _Message;
            Data = _Data;
        }
    }
}
