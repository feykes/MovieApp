using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class MovieDetail
    {
        public int Id { get; set; }
        public bool Adult { get; set; }
        public string Backdrop_path { get; set; }
        public string Belongs_to_collection { get; set; }
        public int Budget { get; set; }
        public List<Genres> Genres { get; set; }
        public string Homepage { get; set; }
        public string Imdb_id { get; set; }
        public string Original_language { get; set; }
        public string Original_title { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string Poster_path { get; set; }
        public List<ProductionCompanies> Production_Companies { get; set; }
        [NotMapped]
        public List<ProductionCountries> Production_Countries { get; set; }
        public string Release_date { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        [NotMapped]
        public List<SpokenLanguages> Spoken_Languages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double Vote_Average { get; set; }
        public int Vote_Count { get; set; }
    }
}
