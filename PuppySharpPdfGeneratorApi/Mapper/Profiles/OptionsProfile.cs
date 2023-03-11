using AutoMapper;
using PuppySharpPdf.Core.Renderers.Configurations;

namespace PuppySharpPdfGeneratorApi.Mapper.Profiles;

public class OptionsProfile : Profile
{
	public OptionsProfile()
	{
		CreateMap<Options, PuppySharpPdf.Core.Renderers.Configurations.PdfOptions>();
		CreateMap<ApiMarginOptions, MarginOptions>();
	}
}
