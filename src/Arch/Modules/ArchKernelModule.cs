using System.Reflection;
using Arch.Dependency;

namespace Arch.Modules
{
    public sealed class ArchKernelModule : ArchModule
    {
        public override void PreInitialize()
        {

            IocManager.AddConventionalRegistrar(new BasicConventionalRegistrar());

            IocManager.Register<IScopedIocResolver, ScopedIocResolver>(DependencyLifeStyle.Transient);
            //IocManager.Register(typeof(IAmbientScopeProvider<>), typeof(DataContextAmbientScopeProvider<>), DependencyLifeStyle.Transient);

            AddAuditingSelectors();
            AddUnitOfWorkFilters();
        }

        public override void Initialize()
        {
 
            IocManager.RegisterAssemblyByConvention(typeof(ArchKernelModule).GetTypeInfo().Assembly,
                new ConventionalRegistrationConfig
                {
                    InstallInstallers = false
                });
        }


        public override void PostInitialize()
        {
            base.PostInitialize();
        }

        public override void Shutdown()
        {
            base.Shutdown();
        }



        private void AddAuditingSelectors()
        {

        }

        private void AddUnitOfWorkFilters()
        {

        }
    }
}
