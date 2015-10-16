using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

namespace Chef.PowerShell
{
    public static class RunspaceExecutor
    {
        private static System.Management.Automation.Runspaces.RunspacePool rp;
        private static System.Management.Automation.PowerShell ps;

        static RunspaceExecutor()
        {
            rp = System.Management.Automation.Runspaces.RunspaceFactory.CreateRunspacePool();
            ps = System.Management.Automation.PowerShell.Create();

            rp.Open();
            ps.RunspacePool = rp;
        }

        public static int ExecutePs(string input)
        {
            var script = "'" + input + "'.length";
            ps.AddScript(script);
            var result = ps.Invoke().First().BaseObject;
            int number = (result as int?).Value;
            return number;
        }
    }
}
