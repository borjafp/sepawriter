using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace SepaWriter.Test
{
    [TestFixture]
    public class SepaCreditTransferTransactionTest
    {
        private const string Bic = "SOGEFRPPXXX";
        private const string Iban = "FR7030002005500000157845Z02";
        private const string Name = "A_NAME";

        private readonly SepaIbanData _iBanData = new SepaIbanData
            {
                Bic = Bic,
                Iban = Iban,
                Name = Name
            };

        [Test]
        public void ShouldHaveADefaultCurrency()
        {
            var data = new SepaCreditTransferTransaction();

            ClassicAssert.AreEqual("EUR", data.Currency);
        }

        [Test]
        public void ShouldKeepProvidedData()
        {
            const decimal amount = 100m;
            const string currency = "USD";
            const string id = "Batch1";
            const string endToEndId = "Batch1/Row2";
            const string remittanceInformation = "Sample";

            var data = new SepaCreditTransferTransaction
                {
                    Creditor = _iBanData,
                    Amount = amount,
                    Currency = currency,
                    Id = id,
                    EndToEndId = endToEndId,
                    RemittanceInformation = remittanceInformation
                };

            ClassicAssert.AreEqual(currency, data.Currency);
            ClassicAssert.AreEqual(amount, data.Amount);
            ClassicAssert.AreEqual(id, data.Id);
            ClassicAssert.AreEqual(endToEndId, data.EndToEndId);
            ClassicAssert.AreEqual(remittanceInformation, data.RemittanceInformation);
            ClassicAssert.AreEqual(Bic, data.Creditor.Bic);
            ClassicAssert.AreEqual(Iban, data.Creditor.Iban);

            var data2 = data.Clone() as SepaCreditTransferTransaction;

            ClassicAssert.NotNull(data2);
            ClassicAssert.AreEqual(currency, data2.Currency);
            ClassicAssert.AreEqual(amount, data2.Amount);
            ClassicAssert.AreEqual(id, data2.Id);
            ClassicAssert.AreEqual(endToEndId, data2.EndToEndId);
            ClassicAssert.AreEqual(remittanceInformation, data2.RemittanceInformation);
            ClassicAssert.AreEqual(Bic, data2.Creditor.Bic);
            ClassicAssert.AreEqual(Iban, data2.Creditor.Iban);
        }

        [Test]
        public void ShouldRejectInvalidCreditor()
        {
            ClassicAssert.That(() => { new SepaCreditTransferTransaction { Creditor = new SepaIbanData() }; },
                Throws.TypeOf<SepaRuleException>().With.Property("Message").Contains("Creditor IBAN data are invalid."));            
        }
    }
}