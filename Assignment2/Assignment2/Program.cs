using Assignment2.DataAccess;
using Assignment2.DataAccess.Entities;
using Assignment2.DataAccess.Repositories.Implements;
using Assignment2.DataAccess.Repositories.Interfaces;
using Assignment2.Service.Services.BookService;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<Book>("Books");
    return builder.GetEdmModel();
}
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookAuthorRepository, BookAuthorRepository>();

// Add services to the container.

builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("odata", GetEdmModel()).Filter().Select().Expand().Count().OrderBy().SetMaxTop(100));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configuration = builder.Configuration;
builder.Services.AddDbContext<eBookStoreContext>(opt =>
{
    opt.UseSqlServer(configuration.GetConnectionString("DBConnString"));
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
