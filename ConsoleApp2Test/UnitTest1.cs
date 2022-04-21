using ConsoleApp2;
using Xunit;
using Xunit.Abstractions;

namespace ConsoleApp2Test
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _output;

        public UnitTest1(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        [Trait("srvice","Basket")]
        public void SumFactTest()
        {
            MathHelper mathHelper = new MathHelper();
            var result = mathHelper.Sum(3, 2);

            Assert.Equal(6, result);
        }

        [Theory]
        [InlineData(5, 2, 10)]
        [InlineData(10, 2, 20)]
        [Trait("srvice", "Order")]
        public void SumInlineDataTest(int x, int y, int expected)
        {
            MathHelper mathHelper = new MathHelper();
            var result = mathHelper.Sum(x, y);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(MemberDataForTest.MemberData), MemberType = typeof(MemberDataForTest))]
        public void SumMemberDataTest(int x, int y, int expected)
        {
            MathHelper mathHelper = new MathHelper();
            var result = mathHelper.Sum(x, y);

            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(ClassDataForTest))]
        public void SumClassDataTest(int x, int y, int expected)
        {
            MathHelper mathHelper = new MathHelper();
            var result = mathHelper.Sum(x, y);
            _output.WriteLine(result.ToString());
            Assert.Equal(expected, result);
        }
    }
}