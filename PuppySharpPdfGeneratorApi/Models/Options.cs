using PuppySharpPdf.Core.Renderers.Configurations;
public class Options
{
	public bool PrintBackground { get; set; } = true;


	public PaperFormat Format { get; set; } = PaperFormat.A4;


	public decimal Scale { get; set; } = 1m;


	public bool DisplayHeaderFooter { get; set; }

	public string HeaderTemplate { get; set; } = string.Empty;


	public string FooterTemplate { get; set; } = string.Empty;


	public bool Landscape { get; set; }

	public string PageRanges { get; set; } = string.Empty;


	public object Width { get; set; }

	public object Height { get; set; }

	public ApiMarginOptions MarginOptions { get; set; } = new ApiMarginOptions();


	public bool PreferCSSPageSize { get; set; }

	public bool OmitBackground { get; set; }
}
