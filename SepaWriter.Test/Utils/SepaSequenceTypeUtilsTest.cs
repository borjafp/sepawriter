using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using SepaWriter.Utils;

namespace SepaWriter.Test.Utils
{
    [TestFixture]
    public class SepaSequenceTypeUtilsTest
    {
        [Test]
        public void ShouldRetrieveSequenceTypeFromString()
        {
            ClassicAssert.AreEqual(SepaSequenceType.OOFF, SepaSequenceTypeUtils.SepaSequenceTypeFromString("OOFF"));
            ClassicAssert.AreEqual(SepaSequenceType.FIRST, SepaSequenceTypeUtils.SepaSequenceTypeFromString("FRST"));
            ClassicAssert.AreEqual(SepaSequenceType.RCUR, SepaSequenceTypeUtils.SepaSequenceTypeFromString("RCUR"));
            ClassicAssert.AreEqual(SepaSequenceType.FINAL, SepaSequenceTypeUtils.SepaSequenceTypeFromString("FNAL"));
        }

        [Test]
        public void ShouldRejectUnknownSequenceType()
        {
            ClassicAssert.That(() => { SepaSequenceTypeUtils.SepaSequenceTypeFromString("unknown value"); },
                Throws.TypeOf<ArgumentException>().With.Property("Message").Contains("Unknown Sequence Type"));
            
        }

        [Test]
        public void ShouldRetrieveStringFromSequenceType()
        {
            ClassicAssert.AreEqual("OOFF", SepaSequenceTypeUtils.SepaSequenceTypeToString(SepaSequenceType.OOFF));
            ClassicAssert.AreEqual("FRST", SepaSequenceTypeUtils.SepaSequenceTypeToString(SepaSequenceType.FIRST));
            ClassicAssert.AreEqual("RCUR", SepaSequenceTypeUtils.SepaSequenceTypeToString(SepaSequenceType.RCUR));
            ClassicAssert.AreEqual("FNAL", SepaSequenceTypeUtils.SepaSequenceTypeToString(SepaSequenceType.FINAL));
        }
    }
}