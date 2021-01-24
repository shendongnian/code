using (new AssertionScope())
{
  (2 + 2).Should().Be(5);
  (2 + 2).Should().Be(6);
}
Or:
**2. Use [FluentAssertions.AssertMultiple][1] NuGet package (the tiny package created by myself):**
AssertMultiple.Multiple(() =>
{
    (2 + 2).Should().Be(5);
    (2 + 2).Should().Be(6);
});
And, when you import static member:
using static FluentAssertions.AssertMultiple.AssertMultiple;
//...
Multiple(() =>
{
    (2 + 2).Should().Be(5);
    (2 + 2).Should().Be(6);
});
  [1]: https://github.com/dariusz-wozniak/FluentAssertions.AssertMultiple
