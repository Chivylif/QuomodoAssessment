using Microsoft.EntityFrameworkCore;
using TEST.Data;
using TEST.Repository;
using TEST.Services.DatabaseServices;
using TEST.Services.ServerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFolderServices, FolderServices>();
builder.Services.AddScoped<IUploadServices, UploadServices>();
builder.Services.AddScoped<IUploadServicesServer, UploadServiceServer>();
builder.Services.AddScoped<IFolderServicesServer, FolderServicesServer>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddDbContext<QuomodoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionString")));


var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
