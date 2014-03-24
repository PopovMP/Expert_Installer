//==============================================================
// Forex Strategy Builder
// Copyright © Miroslav Popov. All rights reserved.
//==============================================================
// THIS CODE IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE.
//==============================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ExpertInstaller.Helpers
{
    public class Container
    {
        private readonly Dictionary<Type, string> serviceNames = new Dictionary<Type, string>();
        private readonly Dictionary<string, Func<object>> services = new Dictionary<string, Func<object>>();

        public DependencyManager Register<TS, TC>() where TC : TS
        {
            return Register<TS, TC>(Guid.NewGuid().ToString());
        }

        public DependencyManager Register<TS, TC>(string name) where TC : TS
        {
            if (!serviceNames.ContainsKey(typeof (TS)))
            {
                serviceNames[typeof (TS)] = name;
            }
            return new DependencyManager(this, name, typeof (TC));
        }

        public T Resolve<T>(string name) where T : class
        {
            return (T) services[name]();
        }

        public T Resolve<T>() where T : class
        {
            return Resolve<T>(serviceNames[typeof (T)]);
        }

        public class DependencyManager
        {
            private readonly Dictionary<string, Func<object>> args;
            private readonly Container container;
            private readonly string name;

            internal DependencyManager(Container container, string name, Type type)
            {
                this.container = container;
                this.name = name;

                ConstructorInfo c = type.GetConstructors().First();
                args = c.GetParameters()
                        .ToDictionary<ParameterInfo, string, Func<object>>(
                            x => x.Name,
                            x => (() => container.services[container.serviceNames[x.ParameterType]]())
                    );

                container.services[name] = () => c.Invoke(args.Values.Select(x => x()).ToArray());
            }

            public DependencyManager AsSingleton()
            {
                object value = null;
                Func<object> service = container.services[name];
                container.services[name] = () => value ?? (value = service());
                return this;
            }

            public DependencyManager WithDependency(string parameter, string component)
            {
                args[parameter] = () => container.services[component]();
                return this;
            }

            public DependencyManager WithValue(string parameter, object value)
            {
                args[parameter] = () => value;
                return this;
            }
        }
    }
}