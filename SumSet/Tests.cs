using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace ConsoleApplication1
{    
    [TestFixture]
    public class ProgramTest
    {
        private void CheckFindSetsThatSumToTotal(int[][] expected, int sizeOfSet, int total, int largestValue) {
            var actual = Program.FindSetsThatSumToTotal(sizeOfSet, total, largestValue);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LookForSetOfSizeOneOfAOneDigitNumber_ExpectOneListOfThatNumberReturned()
        {
            CheckFindSetsThatSumToTotal(new[]{ new[]{2} }, 1, 2, 9);
        }

        [Test]
        public void LookForSetOfSizeOneOfATwoDigitNumber_ExpectNullReturned()
        {
            CheckFindSetsThatSumToTotal(null, 1, 12, 9);
        }

        [Test]
        public void LookForSetOfSizeGreaterThanOneWhichReturnsOneResult_ExpectOneListReturned()
        {
            CheckFindSetsThatSumToTotal(new[]{ new[]{9, 8} }, 2, 17, 9);
        }

        [Test]
        public void LookForSetOfSizeGreaterThanOneWhichReturnsMultipleResults_ExpectCorrectListsReturned()
        {
            CheckFindSetsThatSumToTotal(new[]{ new[]{8, 8}, new[]{9, 7} }, 2, 16, 9);
        }

        [Test]
        public void LookForSetOfSizeGreaterThanOneWhichReturnsNoResults_ExpectNullReturned()
        {
            CheckFindSetsThatSumToTotal(null, 2, 21, 9);
        }

    }
}
