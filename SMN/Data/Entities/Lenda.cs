using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMN.Data.Entities
{
    public class Lenda
    {
        public Guid Id { get; set; }
        public string EmriLendes { get; set; }
        public SmnUser Mesuesi { get; set; }
        public Guid MesuesiId { get; set; }
    }
}
