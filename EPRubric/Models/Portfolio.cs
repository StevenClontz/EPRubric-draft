using System;
using System.Data.Entity;

namespace EPRubric.Models
{
    public class Portfolio
    {
        public int ID { get; set; }

        // Student 7-char user id, e.g. clontsc, jss0001
        public string AUUserID { get; set; }

        // Associated "course"?
        // TODO: not implemented

        // Average scores on each SLO, 1.0 through 3.0
        public decimal CommunicationSlo { get; set; }
        public decimal CriticalSlo { get; set; }
        public decimal TechnicalSlo { get; set; }
        public decimal VisualSlo { get; set; }

        // meta data on ePortfolio
        // TODO: not implemented
        //public int brokenLinks { get; set; }
        //public int artifactCount { get; set; }

        // Any other comments
        public string Comments { get; set; }
    }

    public class PortfolioDBContext : DbContext
    {
        public DbSet<Portfolio> Portfolios { get; set; }
    }
}