    using System;
    using Ninject;
    using Ninject.Activation;
    using Xunit;
    using FluentAssertions;
    public interface IReadRepository<T>
    {
        string FilePath { get; }
    }
    public class FileReadRepo<T> : IReadRepository<T>
    {
        private readonly string filePath;
        public FileReadRepo(string filePath)
        {
            this.filePath = filePath;
        }
        public string FilePath { get { return this.filePath; } }
    }
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
    public class ReadFromFileAttribute : Attribute
    {
        public readonly string Path;
        public ReadFromFileAttribute(string path)
        {
            this.Path = path;
        }
    }
    public class AccountController
    {
        public readonly IReadRepository<string> Repository;
        [ReadFromFile(IntegrationTest.SampleFilePath)]
        public AccountController(IReadRepository<string> repository)
        {
            this.Repository = repository;
        }
    }
    public class IntegrationTest
    {
        public const string SampleFilePath = @"C:\SampleData\login.json";
        [Fact]
        public void Test()
        {
            var kernel = new StandardKernel();
            kernel.Bind(typeof(IReadRepository<>)).To(typeof(FileReadRepo<>))
                .WhenMemberHas<ReadFromFileAttribute>()
                .WithConstructorArgument("filePath", CheckAttributePath);
            kernel.Get<AccountController>().Repository.FilePath.Should().Be(SampleFilePath);
        }
        private static object CheckAttributePath(IContext context)
        {
            var attributes = context.Request.Target.Member.GetCustomAttributes(
                typeof(ReadFromFileAttribute), false);
            return ((ReadFromFileAttribute)attributes[0]).Path;
        }
    }
