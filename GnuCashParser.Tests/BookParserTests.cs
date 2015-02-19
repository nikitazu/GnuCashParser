using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GnuCashParser.Tests
{
    [TestClass]
    public class BookParserTests
    {
        const string _xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<gnc-v2
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
     xmlns:vendor=""http://www.gnucash.org/XML/vendor"">
<gnc:count-data cd:type=""book"">1</gnc:count-data>
<gnc:book version=""2.0.0"">
<book:id type=""guid"">3dd199f14b9d79e170caa4653fa152f2</book:id>
<gnc:count-data cd:type=""commodity"">1</gnc:count-data>
<gnc:count-data cd:type=""account"">3</gnc:count-data>
<gnc:count-data cd:type=""transaction"">3</gnc:count-data>
<gnc:commodity version=""2.0.0"">
  <cmdty:space>ISO4217</cmdty:space>
  <cmdty:id>RUB</cmdty:id>
  <cmdty:get_quotes/>
  <cmdty:quote_source>currency</cmdty:quote_source>
  <cmdty:quote_tz/>
</gnc:commodity>
<gnc:commodity version=""2.0.0"">
  <cmdty:space>ISO4217</cmdty:space>
  <cmdty:id>USD</cmdty:id>
  <cmdty:get_quotes/>
  <cmdty:quote_source>currency</cmdty:quote_source>
  <cmdty:quote_tz/>
</gnc:commodity>
<gnc:commodity version=""2.0.0"">
  <cmdty:space>template</cmdty:space>
  <cmdty:id>template</cmdty:id>
  <cmdty:name>template</cmdty:name>
  <cmdty:xcode>template</cmdty:xcode>
  <cmdty:fraction>1</cmdty:fraction>
</gnc:commodity>
<gnc:pricedb version=""1"">
  <price>
    <price:id type=""guid"">1b7e0859ed3f4905b12023adfb750458</price:id>
    <price:commodity>
      <cmdty:space>ISO4217</cmdty:space>
      <cmdty:id>RUB</cmdty:id>
    </price:commodity>
    <price:currency>
      <cmdty:space>ISO4217</cmdty:space>
      <cmdty:id>USD</cmdty:id>
    </price:currency>
    <price:time>
      <ts:date>2015-01-14 00:00:00 +0300</ts:date>
    </price:time>
    <price:source>user:xfer-dialog</price:source>
    <price:value>100/6783</price:value>
  </price>
  <price>
    <price:id type=""guid"">f5e1a69f55e52f7d76c373b866254890</price:id>
    <price:commodity>
      <cmdty:space>ISO4217</cmdty:space>
      <cmdty:id>RUB</cmdty:id>
    </price:commodity>
    <price:currency>
      <cmdty:space>ISO4217</cmdty:space>
      <cmdty:id>USD</cmdty:id>
    </price:currency>
    <price:time>
      <ts:date>2014-12-29 00:00:00 +0300</ts:date>
    </price:time>
    <price:source>user:xfer-dialog</price:source>
    <price:value>100/5693</price:value>
  </price>
  <price>
    <price:id type=""guid"">6edd272022bf863888e57ee353ccc6da</price:id>
    <price:commodity>
      <cmdty:space>ISO4217</cmdty:space>
      <cmdty:id>RUB</cmdty:id>
    </price:commodity>
    <price:currency>
      <cmdty:space>ISO4217</cmdty:space>
      <cmdty:id>USD</cmdty:id>
    </price:currency>
    <price:time>
      <ts:date>2014-12-01 00:00:00 +0300</ts:date>
    </price:time>
    <price:source>user:xfer-dialog</price:source>
    <price:value>10/519</price:value>
  </price>
  <price>
    <price:id type=""guid"">687df360751fc3d46669ad5726bcbc62</price:id>
    <price:commodity>
      <cmdty:space>ISO4217</cmdty:space>
      <cmdty:id>RUB</cmdty:id>
    </price:commodity>
    <price:currency>
      <cmdty:space>ISO4217</cmdty:space>
      <cmdty:id>USD</cmdty:id>
    </price:currency>
    <price:time>
      <ts:date>2014-10-28 00:00:00 +0300</ts:date>
    </price:time>
    <price:source>user:xfer-dialog</price:source>
    <price:value>100/4301</price:value>
  </price>
  <price>
    <price:id type=""guid"">2c89c027657fb98762943023d1d145e0</price:id>
    <price:commodity>
      <cmdty:space>ISO4217</cmdty:space>
      <cmdty:id>USD</cmdty:id>
    </price:commodity>
    <price:currency>
      <cmdty:space>ISO4217</cmdty:space>
      <cmdty:id>RUB</cmdty:id>
    </price:currency>
    <price:time>
      <ts:date>2014-12-09 00:00:00 +0300</ts:date>
    </price:time>
    <price:source>user:xfer-dialog</price:source>
    <price:value>5499/100</price:value>
  </price>
  <price>
    <price:id type=""guid"">7678a84de654aba2efc897ef5fa41a24</price:id>
    <price:commodity>
      <cmdty:space>ISO4217</cmdty:space>
      <cmdty:id>USD</cmdty:id>
    </price:commodity>
    <price:currency>
      <cmdty:space>ISO4217</cmdty:space>
      <cmdty:id>RUB</cmdty:id>
    </price:currency>
    <price:time>
      <ts:date>2014-12-02 00:00:00 +0300</ts:date>
    </price:time>
    <price:source>user:xfer-dialog</price:source>
    <price:value>5229/100</price:value>
  </price>
</gnc:pricedb>
<gnc:account version=""2.0.0"">
  <act:name>Root Account</act:name>
  <act:id type=""guid"">0931c5e21f0fb8b200a9d5c3db6e805c</act:id>
  <act:type>ROOT</act:type>
</gnc:account>
<gnc:account version=""2.0.0"">
  <act:name>Расходы</act:name>
  <act:id type=""guid"">bba8e28ff918170d512079416a716eb5</act:id>
  <act:type>EXPENSE</act:type>
  <act:commodity>
    <cmdty:space>ISO4217</cmdty:space>
    <cmdty:id>RUB</cmdty:id>
  </act:commodity>
  <act:commodity-scu>100</act:commodity-scu>
  <act:description>Расходы</act:description>
  <act:slots>
    <slot>
      <slot:key>placeholder</slot:key>
      <slot:value type=""string"">true</slot:value>
    </slot>
  </act:slots>
  <act:parent type=""guid"">0931c5e21f0fb8b200a9d5c3db6e805c</act:parent>
</gnc:account>
<gnc:account version=""2.0.0"">
  <act:name>Ремонт дома</act:name>
  <act:id type=""guid"">b43f593c319ae9bf475ddb2af3953b38</act:id>
  <act:type>EXPENSE</act:type>
  <act:commodity>
    <cmdty:space>ISO4217</cmdty:space>
    <cmdty:id>RUB</cmdty:id>
  </act:commodity>
  <act:commodity-scu>100</act:commodity-scu>
  <act:description>Ремонт дома</act:description>
  <act:parent type=""guid"">bba8e28ff918170d512079416a716eb5</act:parent>
</gnc:account>
<gnc:transaction version=""2.0.0"">
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
</gnc:transaction>
<gnc:transaction version=""2.0.0"">
  <trn:id type=""guid"">eca3a707712ef19e2a8aa3d4e63006be</trn:id>
  <trn:currency>
    <cmdty:space>ISO4217</cmdty:space>
    <cmdty:id>RUB</cmdty:id>
  </trn:currency>
  <trn:date-posted>
    <ts:date>2013-12-09 23:00:00 +0300</ts:date>
  </trn:date-posted>
  <trn:date-entered>
    <ts:date>2014-03-02 00:34:19 +0300</ts:date>
  </trn:date-entered>
  <trn:description>Кухня (отдавать маме)</trn:description>
  <trn:slots>
    <slot>
      <slot:key>date-posted</slot:key>
      <slot:value type=""gdate"">
        <gdate>2013-12-10</gdate>
      </slot:value>
    </slot>
    <slot>
      <slot:key>notes</slot:key>
      <slot:value type=""string""></slot:value>
    </slot>
  </trn:slots>
  <trn:splits>
    <trn:split>
      <split:id type=""guid"">1b319c9fa3c52ded24922f01af504201</split:id>
      <split:reconciled-state>n</split:reconciled-state>
      <split:value>10400000/100</split:value>
      <split:quantity>10400000/100</split:quantity>
      <split:account type=""guid"">b43f593c319ae9bf475ddb2af3953b38</split:account>
    </trn:split>
    <trn:split>
      <split:id type=""guid"">c6d49a9b1e3f679a002023db2b5b60a9</split:id>
      <split:reconciled-state>n</split:reconciled-state>
      <split:value>-10400000/100</split:value>
      <split:quantity>-10400000/100</split:quantity>
      <split:account type=""guid"">f7e5c9bd34d8cd881f481d837d98f94d</split:account>
    </trn:split>
  </trn:splits>
</gnc:transaction>
<gnc:transaction version=""2.0.0"">
  <trn:id type=""guid"">bda19566a03e004072ec1bcae8337ca0</trn:id>
  <trn:currency>
    <cmdty:space>ISO4217</cmdty:space>
    <cmdty:id>RUB</cmdty:id>
  </trn:currency>
  <trn:date-posted>
    <ts:date>2013-12-09 23:00:00 +0300</ts:date>
  </trn:date-posted>
  <trn:date-entered>
    <ts:date>2014-09-18 21:51:12 +0300</ts:date>
  </trn:date-entered>
  <trn:description>Прихожая (отдавать маме)</trn:description>
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
      <split:id type=""guid"">dfac909e95bda202e93b3b45085b0152</split:id>
      <split:reconciled-state>n</split:reconciled-state>
      <split:value>5000000/100</split:value>
      <split:quantity>5000000/100</split:quantity>
      <split:account type=""guid"">b43f593c319ae9bf475ddb2af3953b38</split:account>
    </trn:split>
    <trn:split>
      <split:id type=""guid"">6fc04849501a0b36c3a9dc6448dcf55c</split:id>
      <split:reconciled-state>n</split:reconciled-state>
      <split:value>-5000000/100</split:value>
      <split:quantity>-5000000/100</split:quantity>
      <split:account type=""guid"">f7e5c9bd34d8cd881f481d837d98f94d</split:account>
    </trn:split>
  </trn:splits>
</gnc:transaction>
</gnc:book>
</gnc-v2>
";

        [TestMethod]
        public void CanParseBookXml()
        {
            BookParser parser = new BookParser();
            Book book = parser.Parse(_xml);
            CheckIf.EqualId("3dd199f14b9d79e170caa4653fa152f2", book.Id, "Book id should be parsed");

            List<Account> accounts = book.Accounts;
        }
    }
}
