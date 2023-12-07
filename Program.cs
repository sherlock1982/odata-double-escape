using DoubleEscapeOdata;
using DoubleEscapeOdata.Controllers;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(opt =>
{
    var odataBuilder = new ODataConventionModelBuilder();
    var set = odataBuilder.EntitySet<Foo>("Foo");

    var myFunction = odataBuilder.EntityType<Foo>().Collection.Function(nameof(FooController.MyFunction))
        .Returns<string>();
    //myFunction.Parameter<int>("userId");
    myFunction.Parameter<string>("fileName");

    var model = odataBuilder.GetEdmModel();

    opt.AddRouteComponents("xapi/v1", model);
});
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

app.UseAuthorization();

app.MapControllers();

app.Run();
