using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Arch.Events;
using Castle.Windsor;
using Arch.Events.Handlers;
using Shouldly;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Xunit;

namespace Arch.Test.Castle
{
    public class Castle_Interception_Test
    {

        private IWindsorContainer _container;

        private MyHandler _handler;


        public Castle_Interception_Test()
        {
            _container = new WindsorContainer();

            _container.Register(
                Component.For<MyInterceptor>().LifestyleTransient(),
                Component.For<MyHandler>().Interceptors<MyInterceptor>().LifestyleTransient()
            );

            _handler = _container.Resolve<MyHandler>();
        }


        [Fact]
        public void Test_Regular()
        {
            _handler.Handle(new MyEventData());
        }


        [Fact]
        public void Test_Reflection()
        {
            typeof(IEventHandler<MyEventData>).GetMethod("Handle", BindingFlags.Instance | BindingFlags.Public)
                .Invoke(_handler, new object[] {new MyEventData()});
        }




    }



    public class MyHandler : IEventHandler<MyEventData>
    {
        public bool IsIntercepted { get; set; }

        public virtual void Handle(MyEventData eventData)
        {
            IsIntercepted.ShouldBeTrue();
        }
    }

    public class MyEventData : Event
    {
      
    }


    public class MyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            (invocation.InvocationTarget as MyHandler).IsIntercepted = true;
        }
    }
}
