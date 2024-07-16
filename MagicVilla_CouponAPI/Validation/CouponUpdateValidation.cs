using FluentValidation;
using MagicVilla_CouponAPI.Model.Dto;

namespace MagicVilla_CouponAPI.Validation
{
    public class CouponUpdateValidation:AbstractValidator<CouponUpdateDto>
    {
        public CouponUpdateValidation()
        {
            RuleFor(model=>model.Id).NotEmpty().GreaterThan(0);
            RuleFor(model=>model.Name).NotEmpty();
            RuleFor(model=>model.Percent).InclusiveBetween(1,100);

        }
    }

}
