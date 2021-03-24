using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD
{
    [TestClass]
    public class StringCalculator_Add
    {
        private StringCalculator calc;

        [TestInitialize]
        public void StringCalculatorInitialize()
        {
            calc = new StringCalculator();
        }

        [TestMethod]
        public void EmptyString_Zero_Success()
        {
            int zero = calc.Add("");

            Assert.AreEqual(zero, 0);
        }

        [DataRow("2", 2)]
        [DataRow("0", 0)]
        [DataRow("123", 123)]
        [TestMethod]
        public void SingleValue_Value_Success(string data, int value)
        {
            int val = calc.Add(data);

            Assert.AreEqual(val, value);
        }

        [DataRow("1,2", 3)]
        [DataRow("3,12", 15)]
        [DataRow("0,0", 0)]
        [TestMethod]
        public void TwoValuesComma_Sum_Success(string data, int value)
        {
            int sum = calc.Add(data);

            Assert.AreEqual(sum, value);
        }

        [DataRow("1\n2", 3)]
        [DataRow("3\n12", 15)]
        [DataRow("79\n52", 131)]
        [TestMethod]
        public void TwoValuesNewLine_Sum_Success(string data, int value)
        {
            int sum = calc.Add(data);

            Assert.AreEqual(sum, value);
        }

        [DataRow("1,1\n1", 3)]
        [DataRow("22\n22\n22", 66)]
        [DataRow("123,456,789", 1368)]
        [TestMethod]
        public void ThreeValuesMixed_Sum_Success(string data, int value)
        {
            int sum = calc.Add(data);

            Assert.AreEqual(sum, value);
        }

        [DataRow("-1")]
        [DataRow("123,-1")]
        [ExpectedException(typeof(System.ArgumentException))]
        [TestMethod]
        public void NegativeValue_ArgumentException_Failure(string data)
        {
            calc.Add(data);
        }


        [DataRow("1,1\n1001", 2)]
        [DataRow("10000", 0)]
        [TestMethod]
        public void Over1000Ignored_Sum_Success(string data, int value)
        {
            int sum = calc.Add(data);

            Assert.AreEqual(sum, value);
        }

        /*[DataRow("//#\n1#2#3", 6)]
        [DataRow("//?\n1?2,3", 6)]
        [TestMethod]
        public void CustomDelimiter_Sum_Success(string data, int value)
        {
            int sum = calc.Add(data);

            Assert.AreEqual(sum, value);
        }*/
    }
}
