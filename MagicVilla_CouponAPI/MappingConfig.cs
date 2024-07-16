

using AutoMapper;
using MagicVilla_CouponAPI.Model;
using MagicVilla_CouponAPI.Model.Dto;

namespace MagicVilla_CouponAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
    {
        CreateMap<Coupon, CouponCreateDto>().ReverseMap();
        CreateMap<Coupon, CouponDto>().ReverseMap();
    }
}
}
