namespace satisfaction_reports.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rating
    {
        public int id { get; set; }

        public DateTime? Date { get; set; }

        public string Ticket { get; set; }

        public int Score { get; set; }

        public string Comment { get; set; }
    }
}
