using DataAccess.DataContext;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public ApplicationDbContext _context;
        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMovie([FromQuery] Pagination pagination)
        {
            var totalCount = _context.MovieDetails.ToList().Count();
            var movie = _context.MovieDetails.Skip(pagination.Page * pagination.Size).Take(pagination.Size).ToList();
            return Ok(movie);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdMovie(int id)
        {
            var data = _context.MovieDetails.Where(p => p.Id == id).Select(p => new
            {
                Film = p.Original_title,
                FilmKonu = p.Overview,
                Puan = p.Vote_Average,
                Açıklama = p.Tagline
            });
            return Ok(data);
        }
        [HttpGet("MovieService")]
        public async Task<IActionResult> MovieService()
        {
            List<MovieDetail> listModel = new List<MovieDetail>();
            string json = new WebClient().DownloadString("https://api.themoviedb.org/3/movie/550?api_key=4fc3dbcb429bfbb2a53a9940d8d58a8b");
            MovieDetail movie = JsonConvert.DeserializeObject<MovieDetail>(json);
            var data = await _context.MovieDetails.AddAsync(movie);
            await _context.SaveChangesAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> PostMovieScore(int id, double score, string? note)
        {
            var data = await _context.MovieDetails.FindAsync(id);
            data.Vote_Average = score;
            data.Tagline = note;
            await _context.SaveChangesAsync();
            return Ok(data);

        }


    }
}
