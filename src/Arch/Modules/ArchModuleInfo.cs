using Arch.Helpers;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Arch.Modules
{
    public class ArchModuleInfo
    {
        public Assembly Assembly { get; }

        public Type Type { get; }

        public ArchModule Instance { get; set; }

        public bool IsLoadedAsPlugIn { get; }

        public List<ArchModuleInfo> Dependencies { get; }

        /// <summary>
        /// Creates a new AbpModuleInfo object.
        /// </summary>
        public ArchModuleInfo([NotNull] Type type, [NotNull] ArchModule instance, bool isLoadedAsPlugIn)
        {
            Check.NotNull(type, nameof(type));
            Check.NotNull(instance, nameof(instance));

            Type = type;
            Instance = instance;
            IsLoadedAsPlugIn = isLoadedAsPlugIn;
            Assembly = Type.GetTypeInfo().Assembly;

            Dependencies = new List<ArchModuleInfo>();
        }

        public override string ToString()
        {
            return Type.AssemblyQualifiedName ??
                   Type.FullName;
        }
    }
}
