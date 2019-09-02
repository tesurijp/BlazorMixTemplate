using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MixTemplate.Shared
{
    public class NavMenuBase : ComponentBase
    {
#if SERVER_MODE
        public string ExecModeName => "Server";
#else
        public string ExecModeName => "Client";
#endif
    }
}
