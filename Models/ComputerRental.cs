using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerClubBugrina.Models
{
    public class ComputerRental
    {
        public int Id { get; set; }
        public string FioClient { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public ComputerRental (int Id, string FioClient, DateTime ReservationDateTime)
        {
            this.Id = Id;
            this.FioClient = FioClient;
            this.ReservationDateTime = ReservationDateTime;
        }
    }
}
