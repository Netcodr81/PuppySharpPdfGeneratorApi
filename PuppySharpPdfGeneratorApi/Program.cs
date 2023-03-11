using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PuppySharpPdf.Core.Interfaces;
using PuppySharpPdf.Core.Renderers.Configurations;
using PuppySharpPdfGeneratorApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPuppySharpPdfCore(options =>
{
	options.BaseAddress = new Uri("https://localhost:5091");
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapPost("api/generate-pdf", async ([FromBody] PdfGenerationRequest request, [FromServices] IPuppyPdfRenderer renderer) =>
{
	try
	{
		var pdf = await renderer.GeneratePdfFromHtmlAsync(request.HtmlString);

		return Results.File(pdf.Value, "application/pdf", request.FileName);
	}
	catch (Exception)
	{

		return Results.StatusCode(500);
	}
});

app.MapPost("api/generate-pdf-withoptions", async ([FromBody] PdfGenerationRequestWithOptions request, [FromServices] IPuppyPdfRenderer renderer, [FromServices] IMapper mapper) =>
{
	try
	{
		var pdfOptions = mapper.Map<PdfOptions>(request.PdfOptions);

		var pdf = await renderer.GeneratePdfFromHtmlAsync(request.HtmlString, pdfOptions);

		return Results.File(pdf.Value, "application/pdf", request.FileName);
	}
	catch (Exception)
	{

		return Results.StatusCode(500);
	}
});
app.Run();

