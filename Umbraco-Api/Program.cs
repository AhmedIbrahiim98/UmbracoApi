using Umbraco_Api.Startup;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers()
    .EnableSwaggerInProduction()
    .Build();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Umbraco API V1");
    //    c.RoutePrefix = "swagger"; // Sets the Swagger UI at the "/swagger" URL
    //});
    app.UseDeveloperExceptionPage();
}
else
{
    //app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseInstallerEndpoints();
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
