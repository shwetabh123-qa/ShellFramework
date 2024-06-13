using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellTest.Helpers
{
    public class DBConnectionStringDTO
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string TCESserverName { get; set; }
        public string TCESDB { get; set; }
        public string TCESReportingserverName { get; set; }
        public string TCESReportingDB { get; set; }
        public string IntegratedSecurity { get; set; }

        public string PersistSecurityInfo { get; set; }
    }
}
