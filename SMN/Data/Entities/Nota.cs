using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMN.Data.Entities
{
    public class Nota
    {
        public Guid Id { get; set; }
        public int Vleresimi { get; set; }
        public Lenda Lenda { get; set; }
        public Guid LendaId { get; set; }
        public SmnUser Nxenesi { get; set; }
        public Guid NxenesiId { get; set; }
        public SmnUser Mesuesi { get; set; }
        public Guid MesuesiId { get; set; }

    }
}
