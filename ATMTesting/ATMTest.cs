
using ATM;
using System.Collections;

namespace ATMTesting
{
    [TestClass]
    public class ATMTest
    {
        [TestMethod]

        public void withdrawalTest()
        {
            var input = "500";

            var expected = true;

            var obj = new AtmWorking();

            //ACT
            var reader = new StringReader(input);

            Console.SetIn(reader);

            var result = obj.checkBalance;

            //Assert

            Assert.AreEqual(expected, result);

        }

    }
}