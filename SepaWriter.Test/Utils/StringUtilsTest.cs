using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using SepaWriter.Utils;

namespace SepaWriter.Test.Utils
{
    [TestFixture]
    public class StringUtilsTest
    {
        private const string FirstPart = "012345678";

        [Test]
        public void ShouldTruncateATooLongString()
        {
            const string str = FirstPart + "9" + "another part";
            ClassicAssert.AreEqual(FirstPart + "9", StringUtils.GetLimitedString(str, 10));
        }

        [Test]
        public void ShouldNotTruncateSmallString()
        {
            ClassicAssert.AreEqual(FirstPart, StringUtils.GetLimitedString(FirstPart, 10));
            ClassicAssert.Null(StringUtils.GetLimitedString(null, 10));
        }

        [Test]
        public void ShouldNotTruncateNullString()
        {
            ClassicAssert.Null(StringUtils.GetLimitedString(null, 10));
        }

        [Test]
        public void ShouldFormatADate()
        {
            var date = new DateTime(2013, 11, 27);
            ClassicAssert.AreEqual("2013-11-27T00:00:00", StringUtils.FormatDateTime(date));
        }

        [Test]
        public void ShouldCleanUpString()
        {
            ClassicAssert.AreEqual(FirstPart, StringUtils.RemoveInvalidChar(FirstPart));

            var allowedChars = "@/-?:(). ,'\"+";
            ClassicAssert.AreEqual(allowedChars, StringUtils.RemoveInvalidChar(allowedChars));

            ClassicAssert.AreEqual("EAEU", StringUtils.RemoveInvalidChar("éàèù"));
        }
    }
}