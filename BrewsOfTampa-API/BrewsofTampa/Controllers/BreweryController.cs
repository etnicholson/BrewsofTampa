using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BrewsofTampa.Data;
using BrewsofTampa.Models;
using GoogleMaps.LocationServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BrewsofTampa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweryController : ControllerBase
    {

        private readonly IHostingEnvironment _host;
        private readonly ApplicationDbContext _context;
        private readonly GoogleLocationService _location;

        public BreweryController(IHostingEnvironment host, ApplicationDbContext context)
        {
            _host = host;
            _context = context;
            _location = new GoogleLocationService("AIzaSyAuWKhOracjaljDFVEZ90gJwsz82TMmCDQ");

        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm(Name = "file")] IFormFile formData, [FromForm(Name = "data")] string data)
        {
            BreweryDto dto = JsonConvert.DeserializeObject<BreweryDto>(data);

            var point = _location.GetLatLongFromAddress(dto.Address);

            var latitude = point.Latitude;
            var longitude = point.Longitude;


            if (formData == null) return BadRequest("Null File");
            if (formData.Length == 0)
            {
                return BadRequest("Empty File");
            }


            var bExist = await _context.Breweries.FirstOrDefaultAsync(p => p.Lat == latitude && p.Lng == longitude);

            if (bExist != null)
            {
                return BadRequest("Brewery already registered");
            }



            var uploadFilesPath = Path.Combine(_host.WebRootPath, "uploads");
            if (!Directory.Exists(uploadFilesPath))
                Directory.CreateDirectory(uploadFilesPath);
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(formData.FileName);
            var filePath = Path.Combine(uploadFilesPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await formData.CopyToAsync(stream);
            }
            var brewery = new Brewery
            {
                Name = dto.Name,
                Website = dto.Website,
                BeerAdvocate = dto.BeerAdvocate,
                Untapped = dto.Untapped,
                Lat = latitude,
                Lng = longitude,
                LogoUrl = fileName,
                Address = dto.Address
            };

            _context.Breweries.Add(brewery);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpGet("list/")]

        public IActionResult List()
        {

            var breweries = _context.Breweries.ToList();
            return Ok(breweries);
        }
    }
}