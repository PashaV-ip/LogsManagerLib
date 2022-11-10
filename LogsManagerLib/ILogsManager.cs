using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsManagerLib
{
    public interface ILogsManager
    {
        Task WriteLog(string text, string name, DateTime dateTime);
    }
}
