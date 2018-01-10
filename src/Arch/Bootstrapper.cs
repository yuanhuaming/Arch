using Arch.Dependency;
using Arch.Dependency.Installers;
using Castle.Core.Logging;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arch
{
    public class Bootstrapper : IDisposable
    {

        public IIocManager IocManager { get; }
        private ILogger _logger;
    
        public virtual void Initialize()
        {

            ResolveLogger();

            try
            {
                RegisterBootstrapper();
                IocManager.IocContainer.Install(new AbpCoreInstaller());

         
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex.ToString(), ex);
                throw;
            }
        }


        private void RegisterInterceptors()
        {
            
        }

        private void RegisterBootstrapper()
        {
            if (!IocManager.IsRegistered<Bootstrapper>())
            {
                IocManager.IocContainer.Register(
                    Component.For<Bootstrapper>().Instance(this)
                );
            }
        }


        private void ResolveLogger()
        {
            if (IocManager.IsRegistered<ILoggerFactory>())
            {
                _logger = IocManager.Resolve<ILoggerFactory>().Create(typeof(Bootstrapper));
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
