using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticketAutomation.Models
{
    public class Session
    {
        public Session()
        {
            seats = new List<Seats>();
            string[] rows = { "A", "B", "C", "D", "E"};
            string[] numbers = { "1", "2", "3", "4", "5"};
            foreach(string row in rows)
            {
                foreach(string number in numbers)
                {
                    Seats seat = new Seats(row, number);
                    seats.Add(seat);
                }
            }
        }

        public string date { get; set; }
        public string time { get; set; }
        public List<Seats> seats { get; set; }

    }
}
