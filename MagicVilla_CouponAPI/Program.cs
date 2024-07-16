using AutoMapper;
using FluentValidation;
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
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/coupon", (ILogger<Program> _logger) =>
{
    APIResponse response = new APIResponse();   
    _logger.Log(LogLevel.Information,"Getting All Coupons");
    response.Result = CouponStore.CouponsList;
    response.isSuccess = true;
    response.StatusCode=System.Net.HttpStatusCode.OK;
    return Results.Ok(response);

}).WithName("GetCoupons").Produces<IEnumerable<APIResponse>>(200);


app.MapGet("/api/coupon/{id:int}", (ILogger<Program> _logger, int id) =>
{
    APIResponse response = new APIResponse();
    response.Result = CouponStore.CouponsList.FirstOrDefault(u => u.Id == id);
    response.isSuccess = true;
    response.StatusCode = System.Net.HttpStatusCode.OK;
    return Results.Ok(response);
}).WithName("GetCoupon").Produces<APIResponse>(200);



//app.MapGet("/api/coupon/{id:int}", (int id) => {
//    return Results.Ok(CouponStore.CouponsList.FirstOrDefault(u => u.Id == id));
//});


app.MapPost("/api/coupon", async (IMapper _mapper,IValidator<CouponCreateDto> _validator,[FromBody] CouponCreateDto Coupon_C_Dto) => {

    var ValidatorResult= await _validator.ValidateAsync(Coupon_C_Dto);

    if(!ValidatorResult.IsValid)
    {
        return Results.BadRequest(ValidatorResult.Errors.FirstOrDefault().ToString());
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

APIResponse response = new() { isSuccess=false,StatusCode=System.Net.HttpStatusCode.BadRequest};
app.MapPut("/api/coupon", async (IMapper _mapper, IValidator<CouponUpdateDto> _validator, [FromBody] CouponUpdateDto Coupon_u_Dto) => {
    var ValidatorResult = await _validator.ValidateAsync(Coupon_u_Dto);

    if (!ValidatorResult.IsValid)
    {
        return Results.BadRequest(ValidatorResult.Errors.FirstOrDefault().ToString());
    }
 
    Coupon couponStore = CouponStore.CouponsList.FirstOrDefault(u=>u.Id==Coupon_u_Dto.Id);
    couponStore.IsActive= Coupon_u_Dto.IsActive;
    couponStore.Name=Coupon_u_Dto.Name;
    couponStore.Percent = Coupon_u_Dto.Percent;
    couponStore.LastUpdated= DateTime.Now;


 
    response.Result=_mapper.Map<CouponDto>(couponStore);
    response.isSuccess=true;
    response.StatusCode=System.Net.HttpStatusCode.OK;
    return Results.Ok(response);
}).WithName("UpdateCoupon").Accepts<CouponUpdateDto>("application/json").Produces<APIResponse>(200).Produces(400); ;

app.MapDelete("/api/coupon/{id:int}", () => { });

app.UseHttpsRedirection();

app.Run();