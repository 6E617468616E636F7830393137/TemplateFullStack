using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateFullStack.Core.Api.Models
{
    public interface IError
    {
        void SetError(string message);
        //string ErrorObjectIsNull { get; }
    }
}
