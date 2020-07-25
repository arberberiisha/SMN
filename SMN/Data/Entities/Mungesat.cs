using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMN.Data.Entities
{
    public class Mungesat
    {
        public Guid Id { get; set; }
        public bool MeArsyje { get; set; }
        public DateTime Data { get; set; }
        public string? Arsyeja { get; set; }
        public Lenda Lenda { get; set; }
        public Guid LendaId { get; set; }
        public SmnUser Nxenesi { get; set; }
        public Guid NxenesiID { get; set; }
    }
}
