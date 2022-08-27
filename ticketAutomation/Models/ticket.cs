using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticketAutomation.Models
{
    public class ticket : Base
    {
        public ticket()
        {
            creationDate = DateTime.Now.ToString();
        }
        public string creationDate { get; set; }
        public decimal totalPrice  { get; set; }
        public int count  { get; set; }
        public string sessionTime  { get; set; }
        public override string ToString()
        {
            return $"total price is {totalPrice}.";
        }
    }
}
