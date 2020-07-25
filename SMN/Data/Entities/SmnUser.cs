using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMN.Data.Entities
{
    public class SmnUser
    {
        public Guid Id { get; set; }
        public IdentityUser Identity { get; set; }
        public string IdentityId { get; set; }        
        public string Emri { get; set; }
        public string EmriPrindit { get; set; }
        public string Mbiemri { get; set; }
        public DateTime DataELindjes { get; set; }
        public byte[] Foto { get; set; }
    }
}
