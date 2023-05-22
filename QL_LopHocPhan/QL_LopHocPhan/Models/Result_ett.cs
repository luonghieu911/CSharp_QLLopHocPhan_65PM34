using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QL_LopHocPhan.Models
{
    public class Result_ett<T> 
    {
        public EnumErrCode ErrCode { get; set; }
        public T Data { get; set; }
        public string ErrDescription { get; set; }
        public string ErrDetail { get; set; }
        public string Message { get; set; }

        public Result_ett()
        {
            ErrCode = EnumErrCode.Error;
            ErrDescription = string.Empty;
            ErrDetail = string.Empty;
        }
    }
}