using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy access
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        //policy.WithOrigins("https://24h.com.vn");// chỉ cho trang này được gọi API
        policy.AllowAnyOrigin(); // allow all
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                                   options.SerializerSettings.ReferenceLoopHandling
                                   = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                                   );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// start connect db
string connectionString = builder.Configuration.GetConnectionString("API");
builder.Services.AddDbContext<T2207A_API.Entities.T2207aApiContext>(
    options => options.UseSqlServer(connectionString));

// end connect db


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
