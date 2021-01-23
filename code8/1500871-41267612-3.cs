    using FluentAssertions;
    using Xunit;
    
    namespace Weingartner.Lens.Spec
    {
        public class DynamicNotifyingObjectSpec
        {
            class Fixture : DynamicNotifyingObject
            {
                public Fixture (): 
                    base()
                {
                    this.AddProperty<string>("A");
                    this.AddProperty<string>("B");
                    this.SetPropertyValue("A", "AAA");
                    this.SetPropertyValue("B", "BBB");
                }
            }
    
            [Fact]
            public void ShouldBeAbleToAddPropertiesLaterOn()
            {
                var ff = new Fixture();
    
                ff.AddProperty<string>("newProp");
                ff.AddProperty<string>("XXXX");
    
                dynamic f = ff;
    
                ff.SetPropertyValue("newProp", "CCC");
    
                ((object)(f.newProp)).Should().Be("CCC");
                f.XXXX = "XXXX";
                f.newProp = "DDD";
                ((object)(f.newProp)).Should().Be("DDD");
                ((object)(f.XXXX)).Should().Be("XXXX");
            }
    
            [Fact]
            public void ShouldGenerateNotificationOnPropertyChange()
            {
                var a = new string []{"A"};
                var b = new string []{"B"};
                object oa = null;
                object ob = null;
    
                var f = new Fixture();
                dynamic fd = f;
    
                f.PropertyChanged += (sender, ev) =>
                {
                    dynamic s = sender;
                    oa = s.A;
                    ob = s.B;
                };
    
                oa.Should().Be(null);
                ob.Should().Be(null);
    
                fd.A = "A";
    
                oa.Should().Be("A");
                ob.Should().Be("BBB");
    
                fd.B = "B";
    
                oa.Should().Be("A");
                ob.Should().Be("B");
            }
    
    
        }
    }
