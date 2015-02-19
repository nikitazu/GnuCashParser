using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GnuCashParser.Tests
{
    [TestClass]
    public class AccountParserTests
    {
        const string _xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<gnc:account xmlns:gnc=""http://www.gnucash.org/XML/gnc""
    xmlns:act=""http://www.gnucash.org/XML/act""
    xmlns:cmdty=""http://www.gnucash.org/XML/cmdty""
    xmlns:slot=""http://www.gnucash.org/XML/slot""
    version=""2.0.0"">
  <act:name>Сбер-вклад</act:name>
  <act:id type=""guid"">5a977b5e74b8dbaa94239d15c889798d</act:id>
  <act:type>BANK</act:type>
  <act:commodity>
    <cmdty:space>ISO4217</cmdty:space>
    <cmdty:id>RUB</cmdty:id>
  </act:commodity>
  <act:commodity-scu>100</act:commodity-scu>
  <act:slots>
    <slot>
      <slot:key>color</slot:key>
      <slot:value type=""string"">Not Set</slot:value>
    </slot>
  </act:slots>
  <act:parent type=""guid"">4f21b4bc82713c0a03457515456ecb78</act:parent>
</gnc:account>";

        [TestMethod]
        public void CanParseAccountXml()
        {
            Account account = AccountParser.Parse(_xml);
            Assert.AreEqual("Сбер-вклад", account.Name, "Account name should be parsed");
            Assert.AreEqual("BANK", account.Type, "Account type should be parsed");
            CheckIf.EqualId("5a977b5e74b8dbaa94239d15c889798d", account.Id, "Account id should be parsed");
            CheckIf.EqualId("4f21b4bc82713c0a03457515456ecb78", account.ParentId.Value, "Account parent id should be parsed");
            Assert.AreEqual("RUB", account.Commodity, "Account commodity should be parsed");
        }
    }
}
