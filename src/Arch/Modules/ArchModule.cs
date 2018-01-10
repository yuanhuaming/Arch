using Arch.Dependency;
using Castle.Core.Logging;
using System.Reflection;

namespace Arch.Modules
{
    public abstract class ArchModule
    {

        /// <summary>
        /// Gets a reference to the IOC manager.
        /// </summary>
        protected internal IIocManager IocManager { get; internal set; }


        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        public ILogger Logger { get; set; }

        protected ArchModule()
        {
            Logger = NullLogger.Instance;
        }


        public virtual void PreInitialize()
        {

        }

      
        public virtual void Initialize()
        {

        }
 
        public virtual void PostInitialize()
        {

        }
 
        /// <summary>
        /// 当应用关闭的时候会触发
        /// </summary>
        public virtual void Shutdown()
        {

        }


        public virtual Assembly[] GetAdditionalAssemblies()
        {
            return new Assembly[0];
        }

    
      

    }
}
