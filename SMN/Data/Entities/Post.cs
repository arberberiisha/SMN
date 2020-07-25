using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMN.Data.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public byte[] Foto { get; set; }
        public string Titulli { get; set; }
        public string Pershkrimi { get; set; }
        public SmnUser Mesuesi { get; set; }
        public Guid MesuesiId { get; set; }
        public SmnUser Sekretari { get; set; }
        public Guid SekretariId { get; set; }
    }
}
