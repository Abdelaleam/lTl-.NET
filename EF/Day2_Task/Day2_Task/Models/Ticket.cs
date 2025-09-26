using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Task.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int ScreeningId { get; set; }
        public Screening Screening { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
    }
}
