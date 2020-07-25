using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMN.Data.Entities
{
    public class Paralelja
    {
        public Guid Id { get; set; }
        public string Klasa { get; set; }
        public string VitiShkollor { get; set; }
        public int NumriParaleles { get; set; }
        public SmnUser Kujdestari { get; set; }
        public Guid KujdestariId { get; set; }
        public List<ParaleljaNxenesi> Nxenesit { get; set; }

    }
}
