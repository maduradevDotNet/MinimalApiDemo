namespace MagicVilla_CouponAPI.Model.Dto
{
    public class CouponDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Percent { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime Created { get; set; }
    }
}
