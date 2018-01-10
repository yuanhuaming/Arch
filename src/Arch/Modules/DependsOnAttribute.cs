using System;
using System.Collections.Generic;
using System.Text;

namespace Arch.Modules
{
   public  class DependsOnAttribute:Attribute
    {

        public Type[] DependedModuleTypes { get; private set; }


        public DependsOnAttribute(params Type[] dependedModuleTypes)
        {
            DependedModuleTypes = dependedModuleTypes;
        }
    }
}
