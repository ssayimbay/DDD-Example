using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shopi.Ordering.Application.Dtos
{
   public class ResponseDataDto<T>
    {
        public T Data { get; set; }

        public bool IsSuccessful { get; set; }

        public List<string> Errors { get; set; }

        public static ResponseDataDto<T> Success(T data)
        {
            return new ResponseDataDto<T> { Data = data, IsSuccessful = true };
        }

        public static ResponseDataDto<T> Fail(List<string> errors)

        {
            return new ResponseDataDto<T>
            {
                Errors = errors,
                IsSuccessful = false
            };
        }

        public static ResponseDataDto<T> Fail(string error)
        {
            return new ResponseDataDto<T> { Errors = new List<string>() { error }, IsSuccessful = false };
        }
    }
}

