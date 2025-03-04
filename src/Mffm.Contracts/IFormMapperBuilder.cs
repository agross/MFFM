using System.Reflection;

namespace Mffm.Contracts;

public interface IFormMapperBuilder
{
    void RegisterAssembly(Assembly assembly);
    IFormMapper Build(IServiceRegistrationAdapter containerBuilder);
}