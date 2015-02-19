using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GnuCashParser.Tests
{
    [TestClass]
    public class TransactionParserTests
    {
        const string _xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<gnc:transaction
    xmlns:gnc=""http://www.gnucash.org/XML/gnc""
    xmlns:act=""http://www.gnucash.org/XML/act""
    xmlns:book=""http://www.gnucash.org/XML/book""
    xmlns:cd=""http://www.gnucash.org/XML/cd""
    xmlns:cmdty=""http://www.gnucash.org/XML/cmdty""
    xmlns:price=""http://www.gnucash.org/XML/price""
    xmlns:slot=""http://www.gnucash.org/XML/slot""
    xmlns:split=""http://www.gnucash.org/XML/split""
    xmlns:sx=""http://www.gnucash.org/XML/sx""
    xmlns:trn=""http://www.gnucash.org/XML/trn""
    xmlns:ts=""http://www.gnucash.org/XML/ts""
    xmlns:fs=""http://www.gnucash.org/XML/fs""
    xmlns:bgt=""http://www.gnucash.org/XML/bgt""
    xmlns:recurrence=""http://www.gnucash.org/XML/recurrence""
    xmlns:lot=""http://www.gnucash.org/XML/lot""
    xmlns:addr=""http://www.gnucash.org/XML/addr""
    xmlns:owner=""http://www.gnucash.org/XML/owner""
    xmlns:billterm=""http://www.gnucash.org/XML/billterm""
    xmlns:bt-days=""http://www.gnucash.org/XML/bt-days""
    xmlns:bt-prox=""http://www.gnucash.org/XML/bt-prox""
    xmlns:cust=""http://www.gnucash.org/XML/cust""
    xmlns:employee=""http://www.gnucash.org/XML/employee""
    xmlns:entry=""http://www.gnucash.org/XML/entry""
    xmlns:invoice=""http://www.gnucash.org/XML/invoice""
    xmlns:job=""http://www.gnucash.org/XML/job""
    xmlns:order=""http://www.gnucash.org/XML/order""
    xmlns:taxtable=""http://www.gnucash.org/XML/taxtable""
    xmlns:tte=""http://www.gnucash.org/XML/tte""
    xmlns:vendor=""http://www.gnucash.org/XML/vendor""
    version=""2.0.0"">
  <trn:id type=""guid"">419124c2108f39c94378c488dda67348</trn:id>
  <trn:currency>
    <cmdty:space>ISO4217</cmdty:space>
    <cmdty:id>RUB</cmdty:id>
  </trn:currency>
  <trn:date-posted>
    <ts:date>2013-12-09 23:00:00 +0300</ts:date>
  </trn:date-posted>
  <trn:date-entered>
    <ts:date>2014-01-06 15:30:21 +0300</ts:date>
  </trn:date-entered>
  <trn:description>Обои (отдавать маме)</trn:description>
  <trn:slots>
    <slot>
      <slot:key>date-posted</slot:key>
      <slot:value type=""gdate"">
        <gdate>2013-12-10</gdate>
      </slot:value>
    </slot>
  </trn:slots>
  <trn:splits>
    <trn:split>
      <split:id type=""guid"">e739f02a5e4ced52a8974292d183727f</split:id>
      <split:reconciled-state>n</split:reconciled-state>
      <split:value>1000000/100</split:value>
      <split:quantity>1000000/100</split:quantity>
      <split:account type=""guid"">b43f593c319ae9bf475ddb2af3953b38</split:account>
    </trn:split>
    <trn:split>
      <split:id type=""guid"">0db32508c93b252e0acb168787d82289</split:id>
      <split:reconciled-state>n</split:reconciled-state>
      <split:value>-1000000/100</split:value>
      <split:quantity>-1000000/100</split:quantity>
      <split:account type=""guid"">f7e5c9bd34d8cd881f481d837d98f94d</split:account>
    </trn:split>
  </trn:splits>
</gnc:transaction>";

        [TestMethod]
        public void CanParseTransactionXml()
        {
            TransactionParser parser = new TransactionParser();
            Transaction transaction = parser.Parse(_xml);

            CheckIf.EqualId("419124c2108f39c94378c488dda67348", transaction.Id, "Transaction id should be parsed");
            Assert.AreEqual("RUB", transaction.Currency, "Transaction currency should be parsed");
            
            Assert.AreEqual(
                new DateTimeOffset(2013, 12, 9, 23, 00, 00, new TimeSpan(3, 0, 0)),
                transaction.Posted,
                "Transaction posted date should be parsed");

            Assert.AreEqual(
                new DateTimeOffset(2014, 1, 6, 15, 30, 21, new TimeSpan(3, 0, 0)),
                transaction.Entered,
                "Transaction entered date should be parsed");

            Assert.AreEqual("Обои (отдавать маме)", transaction.Description, "Transaction description should be parsed");

            Assert.AreEqual(2, transaction.Splits.Count, "Transaction splits should be parsed");
            
            AssertSplitValues(
                "e739f02a5e4ced52a8974292d183727f", "b43f593c319ae9bf475ddb2af3953b38", 10000.00m, 10000.00m,
                transaction.Splits[0]);

            AssertSplitValues(
                "0db32508c93b252e0acb168787d82289", "f7e5c9bd34d8cd881f481d837d98f94d", -10000.00m, -10000.00m,
                transaction.Splits[1]);
        }

        private static void AssertSplitValues(
            string expectedSplitId,
            string expectedAccountId,
            decimal expectedValue,
            decimal expectedQuantity,
            TransactionSplit actualSplit)
        {
            CheckIf.EqualId(expectedSplitId, actualSplit.Id, "Transaction split id should be parsed");
            Assert.AreEqual(expectedValue, actualSplit.Value, "Transaction split value should be parsed");
            Assert.AreEqual(expectedQuantity, actualSplit.Quantity, "Transaction split quantity should be parsed");
            CheckIf.EqualId(expectedAccountId, actualSplit.AccountId, "Transaction split account id should be parsed");
        }


    }
}
