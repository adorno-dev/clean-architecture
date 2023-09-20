using CleanArchitecture.Application.Extensions;
using CleanArchitecture.Persistence.Extensions;
using CleanArchitecture.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplication();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.CreateDatabase();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
