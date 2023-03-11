namespace PuppySharpPdfGeneratorApi.Models;

public record PdfGenerationRequestWithOptions(string HtmlString, string FileName, Options PdfOptions);