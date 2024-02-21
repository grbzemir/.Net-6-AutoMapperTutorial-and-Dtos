using AutoMapper;

namespace AutoMappperTutorial
{
    public class AutoMapperProfile:Profile
    {

        // Automapper'ın kullanılabilmesi için AutoMapperProfile sınıfı oluşturuldu ve Profile sınıfından kalıtım alındı.
        public AutoMapperProfile()
        {
            CreateMap<SuperHero, SuperHeroDto>();
            CreateMap<SuperHeroDto, SuperHero>();   
            
        }
    }
}
