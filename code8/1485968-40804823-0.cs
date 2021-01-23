    using NUnit.Framework;
    using Rhino.Mocks;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    namespace StackOverflow_namespace
    {
        public interface IUsefulService
        {
            object HiddenAmongManyCalls();
            string TestCall2(string arg1, int arg2);
            string FULLACCESS { get; set; }
            string READONLY { get; }
        }
        public class ThirdPartyBase
        {
            private int a = 42;
            public ThirdPartyBase(IUsefulService service)
            {
                service.TestCall2("callA", 1);
                service.TestCall2("callB", 1);
                object liveFastDieYoung = service.HiddenAmongManyCalls();
                service.TestCall2("callA", 2);
                service.TestCall2("callB", 2);
                var a = service.FULLACCESS;
                var b = service.READONLY;
                service.FULLACCESS = "some";
                liveFastDieYoung.Equals(a);
            }
        }
        public class MyParty : ThirdPartyBase
        {
            public MyParty(IUsefulService service) : base(service)
            {
            }
        }
        [TestFixture]
        class StackOverflow
        {
            [Test]
            public void Hypothetical()
            {
                IUsefulService service = MockRepository.GenerateMock<IUsefulService>();
                try
                {
                    var party = new MyParty(service);
                }
                catch (Exception e)
                {
                    var calls = GetCallsList(service);
                    foreach (var call in calls)
                    {
                        //with my visual studio testrunner for nunit 3 I can investigate stored console output
                        Console.WriteLine(call);
                    }
                    Assert.Fail("Excpexted no exception but was '" + e.GetType().Name + "': " + e.Message);
                }
            }
            private IEnumerable<string> GetCallsList<Interface>(Interface rhinomock)
            {
                Type interfaceType = typeof(Interface);
                List<MethodInfo> interfaceMethodInfos = new List<MethodInfo>();
                List<string> returnInfos = new List<string>();
                StringBuilder callbuilder = new StringBuilder();
                foreach (var property in interfaceType.GetProperties())
                {
                    AddMethodInfoIfValid(interfaceMethodInfos, property.GetGetMethod());
                    AddMethodInfoIfValid(interfaceMethodInfos, property.GetSetMethod());
                }
                foreach (var method in interfaceType.GetMethods())
                {
                    AddMethodInfoIfValid(interfaceMethodInfos, method);
                }
                foreach (var methodinfo in interfaceMethodInfos)
                {
                    int paramcount = methodinfo.GetParameters().Length;
                    object[] args = new object[paramcount];
                    Action<Interface> lambdacall = (i) => methodinfo.Invoke(i, args); 
                    var calls = rhinomock.GetArgumentsForCallsMadeOn(lambdacall);
                    foreach (var call in calls)
                    {
                        bool more = false;
                        callbuilder.Clear().Append(interfaceType.Name).Append('.').Append(methodinfo.Name).Append('(');
                        foreach (var parameter in call)
                        {
                            if (more) { callbuilder.Append(", "); }
                            if (null == parameter) { callbuilder.Append("<null>"); }
                            else {
                                callbuilder
                                    .Append('(').Append(parameter.GetType().Name).Append(")'")
                                    .Append(parameter.ToString()).Append("'");
                            }
                            more = true;
                        }
                        callbuilder.Append(')');
                        string callInfo = callbuilder.ToString();
                        returnInfos.Add(callInfo);
                    }
                }
                return returnInfos;
            }
            private static void AddMethodInfoIfValid(List<MethodInfo> interfaceMethodInfos, MethodInfo methodinfo)
            {
                if (null != methodinfo)
                {
                    interfaceMethodInfos.Add(methodinfo);
                }
            }
        }
    }
