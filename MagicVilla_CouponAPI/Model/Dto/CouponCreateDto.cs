namespace MagicVilla_CouponAPI.Model.Dto
{
    public class CouponCreateDto
    {
        public string Name { get; set; }
        public int Percent { get; set; }
        public Boolean IsActive { get; set; }
    }
}
