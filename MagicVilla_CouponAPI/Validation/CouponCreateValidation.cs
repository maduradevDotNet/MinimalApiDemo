using FluentValidation;
using MagicVilla_CouponAPI.Model.Dto;

namespace MagicVilla_CouponAPI.Validation
{
    public class CouponCreateValidation:AbstractValidator<CouponCreateDto>
    {
        public CouponCreateValidation()
        {
            RuleFor(model=>model.Name).NotEmpty();
            RuleFor(model=>model.Percent).InclusiveBetween(1,100);

        }
    }

}
