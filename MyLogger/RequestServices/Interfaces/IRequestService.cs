using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.RequestServices.Interfaces
{
    public interface IRequestService
    {
        Task<string> GetPage();
    }
}
