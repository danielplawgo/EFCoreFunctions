using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreFunctions
{
    public class AuditLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;

        public string LogType { get; set; }

        public string Data { get; set; }
    }
}
