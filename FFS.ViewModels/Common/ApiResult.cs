using System;
using System.Collections.Generic;
using System.Text;

namespace FFS.ViewModels.Common
{
    public class ApiResult<T>
    {
        public bool IsSuccessed { get; set; }

        public string Message { get; set; }

        public T ResultObj { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
