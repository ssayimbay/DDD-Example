using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopi.Ordering.Application.Dtos
{
    public class ResponseDto
    {
        public bool IsSuccessful { get; private set; }

        public List<string> Errors { get; set; }


        public static ResponseDto Success()
        {
            return new ResponseDto { IsSuccessful = true};
        }

        public static ResponseDto Fail(List<string> errors)
        {
            return new ResponseDto { IsSuccessful = false,Errors = errors };
        }

        public static ResponseDto Fail(string error)
        {
            return new ResponseDto { IsSuccessful = false, Errors = new List<string>{ error } };
        }

    }
}
