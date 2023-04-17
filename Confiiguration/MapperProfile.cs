using AutoMapper;
using WebApplicationExample.DTO;
using WebApplicationExample.Models;

namespace WebApplicationExample.Confiiguration
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Article, ArticleDTO>();
            CreateMap<ArticleDTO, Article>();
        }
    }
}
