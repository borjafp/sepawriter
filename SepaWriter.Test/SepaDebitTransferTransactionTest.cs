using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace SepaWriter.Test
{
    [TestFixture]
    public class SepaDebitTransferTransactionTest
    {
        private const string Bic = "SOGEFRPPXXX";
        private const string Iban = "FR7030002005500000157845Z02";
        private const string Name = "A_NAME";

        private readonly SepaIbanData iBanData = new SepaIbanData
            {
                Bic = Bic,
                Iban = Iban,
                Name = Name
            };

        [Test]
        public void ShouldHaveADefaultCurrency()
        {
            var data = new SepaDebitTransferTransaction();

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
            const string mandateId = "MyMandate";
            var signatureDate = new DateTime(2012, 12, 2);
            var seqType = SepaSequenceType.FIRST;

            var data = new SepaDebitTransferTransaction
                {
                    Debtor = iBanData,
                    Amount = amount,
                    Currency = currency,
                    Id = id,
                    EndToEndId = endToEndId,
                    RemittanceInformation = remittanceInformation,
                    DateOfSignature = signatureDate,
                    MandateIdentification = mandateId,
                    SequenceType = SepaSequenceType.FIRST
                };

            ClassicAssert.AreEqual(currency, data.Currency);
            ClassicAssert.AreEqual(amount, data.Amount);
            ClassicAssert.AreEqual(id, data.Id);
            ClassicAssert.AreEqual(endToEndId, data.EndToEndId);
            ClassicAssert.AreEqual(remittanceInformation, data.RemittanceInformation);
            ClassicAssert.AreEqual(Bic, data.Debtor.Bic);
            ClassicAssert.AreEqual(Iban, data.Debtor.Iban);
            ClassicAssert.AreEqual(Iban, data.Debtor.Iban);
            ClassicAssert.AreEqual(mandateId, data.MandateIdentification);
            ClassicAssert.AreEqual(signatureDate, data.DateOfSignature);
            ClassicAssert.AreEqual(seqType, data.SequenceType);

            var data2 = data.Clone() as SepaDebitTransferTransaction;

            ClassicAssert.NotNull(data2);
            ClassicAssert.AreEqual(currency, data2.Currency);
            ClassicAssert.AreEqual(amount, data2.Amount);
            ClassicAssert.AreEqual(id, data2.Id);
            ClassicAssert.AreEqual(endToEndId, data2.EndToEndId);
            ClassicAssert.AreEqual(remittanceInformation, data2.RemittanceInformation);
            ClassicAssert.AreEqual(Bic, data2.Debtor.Bic);
            ClassicAssert.AreEqual(Iban, data2.Debtor.Iban);
            ClassicAssert.AreEqual(mandateId, data2.MandateIdentification);
            ClassicAssert.AreEqual(signatureDate, data2.DateOfSignature);
            ClassicAssert.AreEqual(seqType, data2.SequenceType);
        }

        [Test]
        public void ShouldRejectInvalidDebtor()
        {
            ClassicAssert.That(() => { new SepaDebitTransferTransaction { Debtor = new SepaIbanData() }; },
                Throws.TypeOf<SepaRuleException>().With.Property("Message").Contains("Debtor IBAN data are invalid."));
        }

        [Test]
        public void ShouldUseADefaultSequenceType()
        {
            var transfert = new SepaDebitTransferTransaction();
            ClassicAssert.AreEqual(SepaSequenceType.OOFF, transfert.SequenceType);
        }
    }
}