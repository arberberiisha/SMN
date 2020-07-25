using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMN.Data.Entities
{
    public class ParaleljaNxenesi
    {
        public Guid Id { get; set; }
        public SmnUser Nxenesi { get; set; }
        public Paralelja Paralelja { get; set; }
    }
}
