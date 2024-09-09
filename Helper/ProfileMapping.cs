using CatstgramApp.Dtos;
using CatstgramApp.Models;
using Core.Entities;

//using ;
using Core.Entities.Identity;
using Core.Models;

namespace CatstgramApp.Helper
{
    public class ProfileMapping : AutoMapper.Profile
    {
        public ProfileMapping()
        {


            CreateMap<RegisterDto, AppUser>()
                .ForMember(des => des.Email, options => options.MapFrom(src => src.Email))
                .ForMember(des => des.Email,
                options => options.MapFrom(src => src.Email))
                .ForMember(des => des.DisplayName,
               options => options.MapFrom(src => src.Name))
                .ForMember(des => des.UserName,
               options => options.MapFrom(src => src.Name));


            CreateMap<CatDto, Cat>()
                .ForMember(des => des.Description, options => options.MapFrom(src => src.Description))
                .ForMember(des => des.ImageUrl,
                options => options.MapFrom(src => src.ImageUrl))
                .ForMember(des => des.Name,
                options => options.MapFrom(src => src.Name));
            //CreateMap<CatListingResponseModel, Cat>()
            //    .ForMember(des => des.Id, options => options.MapFrom(src => src.Id))
            //    .ForMember(des => des.ImageUrl, options => options.MapFrom(src => src.ImageUrl));

            CreateMap<Cat, CatListingResponseModel>()
               .ForMember(des => des.Id, options => options.MapFrom(src => src.Id))
               .ForMember(des => des.ImageUrl, options => options.MapFrom(src => src.ImageUrl));

            CreateMap<Cat, CatDetailsResponseModel>()
               .ForMember(des => des.Name, options => options.MapFrom(src => src.Name))
               .ForMember(des => des.Description, options => options.MapFrom(src => src.Description))
               .ForMember(des => des.UserId, options => options.MapFrom(src => src.UserId));
            //CreateMap<Profile, ProfileResponseServiceModel>().ReverseMap();

        }
    }
}
