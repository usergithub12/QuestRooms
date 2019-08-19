﻿using System;
using System.Collections.Generic;

namespace QuestRooms.DAL.Entities
{
  public  class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual Company Company { get; set; }
        public virtual Address Adress { get; set; }
        public TimeSpan AllTime { get; set; }
        public int Rating { get; set; }
        public int LvlFear { get; set; }
        public int LvlDifficulty { get; set; }
        public string Logo { get; set; }
        public ICollection<Image> Images { get; set; }                                     
    }
}