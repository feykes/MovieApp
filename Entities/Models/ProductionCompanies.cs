using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ProductionCompanies
    {
        public int Id { get; set; }
        public string Logo_Path { get; set; }
        public string Name { get; set; }
        public string Origin_Country { get; set; }
        public int MovieDetailId { get; set; }
        public MovieDetail MovieDetail { get; set; }

    }
}
