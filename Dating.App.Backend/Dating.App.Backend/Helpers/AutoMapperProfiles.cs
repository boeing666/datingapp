using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dating.App.Backend.Models;
using Dating.App.Backend.Models.RequestModels;
using Dating.App.Backend.Models.ResponseModels;

namespace Dating.App.Backend.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        //გვეხმარება ავტომატურად დავაკონვერტიროთ რესპონსის კლასად ბაზიდან წამოღებული ინფორმაცია
        public AutoMapperProfiles()
        {
            CreateMap<User, UserListModel>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest=>dest.Age, opt=>opt.MapFrom(src=>
                    src.DateOfBirth.CalculateAge()));

            CreateMap<User, UserDetailModel>()
                .ForMember(dest=>dest.PhotoUrl, opt=>
                    opt.MapFrom(src=>src.Photos.FirstOrDefault(p=>p.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src =>
                    src.DateOfBirth.CalculateAge()));
            ;
            CreateMap<Photo, PhotosForUserDetailModel>();
        }
    }
}
