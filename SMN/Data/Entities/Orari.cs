using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMN.Data.Entities
{
    public class Orari
    {
        public Guid Id { get; set; }

        public string Dita { get; set; }
        
        public string Ora { get; set; }

        public Paralelja Paralelja { get; set; }

        public Guid ParaleljaID { get; set; }

        public SmnUser Mesuesi { get; set; }
        public Guid MesuesiID { get; set; }
        public Lenda Lenda { get; set; }
        public Guid LendaID { get; set; }
    }
}
