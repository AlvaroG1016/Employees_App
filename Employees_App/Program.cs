using Employees_App.Clients;
using Employees_App.Constants;
using Employees_App.Interfaces.Clients;
using Employees_App.Interfaces.Services;
using Employees_App.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var EmployeeSpecificOrigins = "_employeeAppSpecificOrigins";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: EmployeeSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

builder.Services.AddHttpClient<IEmployeeApiClient, EmployeeApiClient>(client =>
{
    client.BaseAddress = new Uri(ProjectConstants.ApiConstants.BaseUrl);
});
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(EmployeeSpecificOrigins);

app.MapControllers();

app.Run();
