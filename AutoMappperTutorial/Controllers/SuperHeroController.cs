using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMappperTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        //Automapper farklı tipteki complex objeleri birbirlerine otomatik olarak dönüştüren kütüphanedir.
        //Bu kütüphane ile DTO ve Model arasında dönüşüm yapabiliriz.

        private static List<SuperHero> Heroes = new List<SuperHero>
        {
            new SuperHero

            {

                Id = 1,
                Name = "Superman",
                FirstName = "Clark",
                LastName = "Kent",
                Place = "Metropolis",
                DateAdded = new DateTime(1938, 4, 18),
                DateModified = null

            },
            new SuperHero

            {

                Id = 2,
                Name = "Batman",
                FirstName = "Bruce",
                LastName = "Wayne",
                Place = "Gotham",
                DateAdded = new DateTime(1939, 5, 1),
                DateModified = null


            }
        };

        private readonly IMapper _mapper; // Automapper'ı kullanabilmek için IMapper interface'ini kullanıyoruz.

        // Yapıcı metot olusturuldu
        public SuperHeroController(IMapper mapper)
        {
            _mapper = mapper;
        }

        


        [HttpGet]

        public ActionResult<List<SuperHero>> GetHeroes()
        {
             
            //var shDto = new SuperHeroDto();
            //shDto.Name = Heroes[0].Name;
            //shDto.FirstName = Heroes[0].FirstName;
            //shDto.LastName = Heroes[0].LastName;
            //shDto.Place = Heroes[0].Place;
            
            
            return  Ok(Heroes.Select(hero => _mapper.Map<SuperHeroDto>(hero)));

    }

        [HttpPost]

        public ActionResult<List<SuperHero>> AddHero(SuperHeroDto newHero)

        {
            var Hero = _mapper.Map<SuperHero>(newHero);
            Heroes.Add(Hero);
            return Ok(Heroes.Select(hero => _mapper.Map<SuperHeroDto>(Hero)));
        } 
        
     }

  }

