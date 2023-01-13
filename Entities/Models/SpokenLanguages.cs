using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SpokenLanguages
    {
        public string English_Name { get; set; }
        public string Iso_639_1 { get; set; }
        public string Name { get; set; }

    }
}
