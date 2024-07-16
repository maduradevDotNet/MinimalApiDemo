using AutoMapper;
using MagicVilla_CouponAPI;
using MagicVilla_CouponAPI.Data;
using MagicVilla_CouponAPI.Model;
using MagicVilla_CouponAPI.Model.Dto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(MagicVilla_CouponAPI.MappingConfig));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/coupon", (ILogger<Program> _logger) =>
{
    _logger.Log(LogLevel.Information,"Getting All Coupons");
    return Results.Ok(CouponStore.CouponsList);
}).WithName("GetCoupons").Produces<IEnumerable<Coupon>>(200);


app.MapGet("/api/coupon/{id:int}", (int id) =>
{
    return Results.Ok(CouponStore.CouponsList.FirstOrDefault(u => u.Id == id));
}).WithName("GetCoupon").Produces<Coupon>(200);



//app.MapGet("/api/coupon/{id:int}", (int id) => {
//    return Results.Ok(CouponStore.CouponsList.FirstOrDefault(u => u.Id == id));
//});


app.MapPost("/api/coupon", (IMapper _mapper,[FromBody] CouponCreateDto Coupon_C_Dto) => {
    if(string.IsNullOrEmpty(Coupon_C_Dto.Name))
    {
        return Results.BadRequest("Invalid Id or Code name");
    }
    if (CouponStore.CouponsList.FirstOrDefault(u=>u.Name.ToLower()== Coupon_C_Dto.Name.ToLower())!=null)
    {
        return Results.BadRequest("Coupon Name Already Excited");
    }
    Coupon coupon = _mapper.Map<Coupon>(Coupon_C_Dto);


    //Coupon coupon = new Coupon {
    //    IsActive= Coupon_C_Dto.IsActive,
    //    Percent= Coupon_C_Dto.Percent,
    //    Name= Coupon_C_Dto.Name
    //};

    coupon.Id=CouponStore.CouponsList.OrderByDescending(u=>u.Id).FirstOrDefault().Id+1;
    CouponStore.CouponsList.Add(coupon);

    CouponDto couponDto=_mapper.Map<CouponDto>(coupon);
    //CouponDto couponDto = new CouponDto { 
    //    Id=coupon.Id,
    //    Name=coupon.Name,
    //    IsActive=coupon.IsActive,
    //    Percent=coupon.Percent,
    //    Created=coupon.Created
    //};
    return Results.CreatedAtRoute("GetCoupon",new {id= coupon.Id}, Coupon_C_Dto);
   // return Results.Created($"/api/coupon/{obj.Id}", obj);
}).WithName("CreateCoupon").Accepts<CouponCreateDto>("application/json").Produces<CouponDto>(201).Produces(400);

app.MapPut("/api/coupon/{id:int}", () => { });
app.MapDelete("/api/coupon/{id:int}", () => { });

app.UseHttpsRedirection();

app.Run();