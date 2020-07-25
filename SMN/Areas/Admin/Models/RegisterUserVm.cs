using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMN.Areas.Admin.Models
{
    public class RegisterUserVm
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Emri { get; set; }
        public string EmriPrindit { get; set; }
        public string Mbiemri { get; set; }
        public DateTime DataELindjes { get; set; }
        public byte[] Foto { get; set; }
        public string Roli { get; set; }
    }
}
