using MagicVilla_CouponAPI.Data;
using MagicVilla_CouponAPI.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/coupon", () => {
    return Results.Ok(CouponStore.CouponsList);
    });

app.MapGet("/api/coupon/{id:int}", (int id) => {
    return Results.Ok(CouponStore.CouponsList.FirstOrDefault(u=>u.Id==id));
});


app.MapPost("/api/coupon", ([FromBody] Coupon obj) => {
    if(obj.Id!=0 || string.IsNullOrEmpty(obj.Name))
    {
        return Results.BadRequest("Invalid Id or Code name");
    }
    if (CouponStore.CouponsList.FirstOrDefault(u=>u.Name.ToLower()==obj.Name.ToLower())!=null)
    {
        return Results.BadRequest("Coupon Name Already Excited");
    }
    obj.Id=CouponStore.CouponsList.OrderByDescending(u=>u.Id).FirstOrDefault().Id+1;
    CouponStore.CouponsList.Add(obj);
    return Results.Ok(obj);

});
app.MapPut("/api/coupon/{id:int}", () => { });
app.MapDelete("/api/coupon/{id:int}", () => { });

app.UseHttpsRedirection();

app.Run();