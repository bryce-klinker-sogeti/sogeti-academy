using Microsoft.Extensions.DependencyInjection;

namespace Sogeti.Academy.Infrastructure.DependencyInjection
{
	public interface IRegistrar
	{
		void RegisterServices(IServiceCollection services);
	}
}