using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SMN.Data.Entities
{
    public class Ligjerata
    {
        public Guid Id { get; set; }
        public string Emri { get; set; }
        public byte[] File { get; set; }
        public Guid MesuesiId { get; set; }
        public SmnUser Mesuesi { get; set; }
        public Guid LendaId { get; set; }
        public Lenda Lenda { get; set; }
        public Paralelja Paralelja { get; set; }
        public Guid ParaleljaId { get; set; }

    }
}
