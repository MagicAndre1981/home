using ExtendedXmlSerializer.ContentModel.Content;
using ExtendedXmlSerializer.ExtensionModel.Types;

namespace ExtendedXmlSerializer.ExtensionModel.Content.Members
{
	sealed class ParameterizedResultHandler : IInnerContentResult
	{
		readonly IInnerContentResult _result;

		public ParameterizedResultHandler(IInnerContentResult result) => _result = result;

		public object Get(IInnerContent parameter)
			=> parameter.Current is IActivationContext context ? context.Get() : _result.Get(parameter);
	}
}