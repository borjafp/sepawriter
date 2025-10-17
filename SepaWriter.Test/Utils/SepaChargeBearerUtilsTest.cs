using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using SepaWriter.Utils;

namespace SepaWriter.Test.Utils
{
    [TestFixture]
    public class SepaChargeBearerUtilsTest
    {
        [Test]
        public void ShouldRetrieveChargeBearerFromString()
        {
            ClassicAssert.AreEqual(SepaChargeBearer.CRED,  SepaChargeBearerUtils.SepaChargeBearerFromString("CRED"));
            ClassicAssert.AreEqual(SepaChargeBearer.DEBT, SepaChargeBearerUtils.SepaChargeBearerFromString("DEBT"));
            ClassicAssert.AreEqual(SepaChargeBearer.SHAR,  SepaChargeBearerUtils.SepaChargeBearerFromString("SHAR"));
        }

        [Test]
        public void ShouldRejectUnknownChargeBearer()
        {
            ClassicAssert.That(() => { SepaChargeBearerUtils.SepaChargeBearerFromString("unknown value"); },
                Throws.TypeOf<ArgumentException>().With.Property("Message").Contains("Unknown Charge Bearer"));
            
        }

        [Test]
        public void ShouldRetrieveStringFromChargeBearer()
        {
            ClassicAssert.AreEqual("CRED", SepaChargeBearerUtils.SepaChargeBearerToString(SepaChargeBearer.CRED));
            ClassicAssert.AreEqual("DEBT", SepaChargeBearerUtils.SepaChargeBearerToString(SepaChargeBearer.DEBT));
            ClassicAssert.AreEqual("SHAR", SepaChargeBearerUtils.SepaChargeBearerToString(SepaChargeBearer.SHAR));
        }
    }
}