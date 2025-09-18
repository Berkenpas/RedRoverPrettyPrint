using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedRoverPrettyPrint.Core;

public interface ITreeStringParser
{
    string Parse(string inputString, bool alphabatize);
}
