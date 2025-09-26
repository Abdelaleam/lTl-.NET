using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Task.Models
{
    public class Screening
    {
        public int ScreeningId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
        public DateTime ScreeningTime { get; set; }
        public int AvailableSeats { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
