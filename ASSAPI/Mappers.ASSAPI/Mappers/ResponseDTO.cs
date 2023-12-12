using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers.ASSAPI.Mappers
{
    public class ResponseDTO
    {
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
        public object Data { get; set; }

    }
}
