﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTravel.BLL.DTOs
{
    public  class ResponseDTO
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public object Data { get; set; }
    }
}
