using SystemTestingVariant9;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Variant9UnitTesting.Work_4_Unit_Testing
{
    [TestClass]
    public class NumberCheckerUnitTests
    {
        [TestMethod]
        public void Test_CheckIfPrime()
        {
            Assert.AreEqual(true, NumberChecker.CheckIfPrime(5));
            Assert.AreEqual(true, NumberChecker.CheckIfPrime(3));
            Assert.AreEqual(true, NumberChecker.CheckIfPrime(11));
            Assert.AreEqual(true, NumberChecker.CheckIfPrime(2053));
            Assert.AreEqual(true, NumberChecker.CheckIfPrime(2039));

            Assert.AreEqual(false, NumberChecker.CheckIfPrime(2047));
            Assert.AreEqual(false, NumberChecker.CheckIfPrime(-31));
            Assert.AreEqual(false, NumberChecker.CheckIfPrime(15));
            Assert.AreEqual(false, NumberChecker.CheckIfPrime(10));
            Assert.AreEqual(false, NumberChecker.CheckIfPrime(1000));
        }

        [TestMethod]
        public void Test_CheckIfNextIsPrimePowerOfTwo()
        {
            Assert.AreEqual(true, NumberChecker.CheckIfNextIsPrimePowerOfTwo(31));
            Assert.AreEqual(true, NumberChecker.CheckIfNextIsPrimePowerOfTwo(2047));

            Assert.AreEqual(false, NumberChecker.CheckIfNextIsPrimePowerOfTwo(32));
            Assert.AreEqual(false, NumberChecker.CheckIfNextIsPrimePowerOfTwo(16));
            Assert.AreEqual(false, NumberChecker.CheckIfNextIsPrimePowerOfTwo(6));
            Assert.AreEqual(false, NumberChecker.CheckIfNextIsPrimePowerOfTwo(-5));
        }
    }
}
