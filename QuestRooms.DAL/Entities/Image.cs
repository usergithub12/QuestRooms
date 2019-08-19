﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRooms.DAL.Entities
{
  public  class Image
    {
        public int Id { get; set; }

        public string Path { get; set; }
        public virtual Room Room { get; set; }
    }
}