﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuestRooms.UI.Models
{
    public class LoginVM
    {
        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}