﻿using System;
using Ninject.Injection;
using Ninject.Planning.Directives;
using Xunit;
using Xunit.Should;

namespace Ninject.Tests.Unit.PropertyInjectionDirectiveTests
{
    public class PropertyInjectionDirectiveContext
    {
        protected PropertyInjectionDirective directive;
    }

    public class WhenDirectiveIsCreated : PropertyInjectionDirectiveContext
    {
        [Fact]
        public void CreatesTargetForProperty()
        {
            var method = typeof(Dummy).GetProperty("Foo");
            PropertyInjector injector = delegate { };

            directive = new PropertyInjectionDirective(method, injector);

            directive.Target.Name.ShouldBe("Foo");
            directive.Target.Type.ShouldBe(typeof(int));
        }
    }

    public class Dummy
    {
        public int Foo { get; set; }
    }
}