using System;

namespace satisfaction
{
    public class Rating
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public string Ticket { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
    }
}