using Microsoft.AspNetCore.Mvc;
using WhereToWatch.Domains.Models;
using WhereToWatch.Domains.Services;

namespace WhereToWatch.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WhereToWatchController : ControllerBase
    {
        public List<Streaming> Streamings = new List<Streaming>()
        {
            new Streaming()
            {
                Id = 1,
                Name = "Netflix",
                Amount = 100
            },
            new Streaming()
            {
                Id = 2,
                Name = "AmazonPrime",
                Amount = 120
            },
            new Streaming()
            {
                Id =3,
                Name = "HboGo",
                Amount= 80
            },
            new Streaming()
            {
                Id =4,
                Name = "DisneyPlus",
                Amount = 110
            },
        };

        public WhereToWatchController() { }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(Streamings);
        }

        [HttpGet("{name:string}")]
        public IActionResult GetById(string name)
        {
            var streaming = Streamings.FirstOrDefault(s => s.Name == name);
            if (streaming == null) return BadRequest();

            return Ok(streaming);
        }

        [HttpPost()]
        public IActionResult Post([FromBody] Streaming newStreaming)
        {
            if (Streamings.Any(x => x.Id == newStreaming.Id)) return BadRequest("Streaming já existente");
            Streamings.Add(newStreaming);
            return Ok(Streamings);
        }

        [HttpPut()]
        public IActionResult Put([FromBody] Streaming newStreamingToUpdate)
        {
            var streamingToUpdate = Streamings.FirstOrDefault(x => x.Id == newStreamingToUpdate.Id);
            if (streamingToUpdate is null) return NotFound("Streaming não encontrado");
            streamingToUpdate = newStreamingToUpdate; 
            return Ok(streamingToUpdate);
        }

        [HttpDelete()]
        public IActionResult Delete(string name)
        {
            var i = 0;
            foreach (var streaming in Streamings)
            {
                if (streaming.Name == name)
                    break;
                else
                    i++;
            }
            if (i >= Streamings.Count)
                return BadRequest("Streaming não encontrado");

            Streamings.RemoveAt(i);
            return Ok(Streamings);
        }
    }
}