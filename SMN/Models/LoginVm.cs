﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMN.Models
{
    public class LoginVm
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
