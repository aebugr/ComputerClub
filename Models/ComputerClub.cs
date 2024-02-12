﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClubBugrina.Models
{
    public class ComputerClub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime WorkTime { get; set; }
        public ComputerClub(int Id, string Name, string Address, DateTime WorkTime)
        {
            this.Id = Id;
            this.Name = Name;
            this.Address = Address;
            this.WorkTime = WorkTime;
        }
    }
}
