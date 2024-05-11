using static TwoSumTask;

namespace LeetcodeTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDictionary()
        {
            var dict = new SuperDictionary(10);

            dict[1] = 12;
            dict[2] = 11;
            dict[11] = 10;
            dict[3] = 9;
            dict[21] = 10;

            Assert.IsTrue(dict.ContainsKey(1));
            Assert.IsTrue(dict.ContainsKey(11));
            Assert.AreEqual(1, 1);
}
        }
    }