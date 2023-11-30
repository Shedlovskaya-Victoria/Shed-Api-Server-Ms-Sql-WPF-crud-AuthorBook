using Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.DTO;
using Shed_Api_Server_Ms_Sql_WPF_crud_AuthorBook.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(s=>s.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddScoped<AuthorCRUD>();
builder.Services.AddScoped<BookCRUD>();
builder.Services.AddScoped<GanreCRUD>();

builder.Services.AddDbContext<User02Context>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
