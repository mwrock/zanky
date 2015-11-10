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

        public static string ExecutePs(string input)
        {
            ps.AddScript(input);
            ps.AddCommand("ConvertTo-JSON");
            var result = ps.Invoke().First().BaseObject.ToString();
            return result;
        }
    }
}
