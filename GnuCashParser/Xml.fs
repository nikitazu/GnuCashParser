namespace GnuCashParser

open System
open System.Xml.Linq

module Xml =
    let XBook    = XName.Get("book", "http://www.gnucash.org/XML/gnc")
    let XAccount = XName.Get("account", "http://www.gnucash.org/XML/gnc")

    let BookId              = XName.Get("id", "http://www.gnucash.org/XML/book")
    let CommodityId         = XName.Get("id", "http://www.gnucash.org/XML/cmdty")

    let AccountName         = XName.Get("name", "http://www.gnucash.org/XML/act")
    let AccountType         = XName.Get("type", "http://www.gnucash.org/XML/act")
    let AccountId           = XName.Get("id", "http://www.gnucash.org/XML/act")
    let AccountCommodity    = XName.Get("commodity", "http://www.gnucash.org/XML/act")
    let AccountParent       = XName.Get("parent", "http://www.gnucash.org/XML/act")

    let SplitId             = XName.Get("id", "http://www.gnucash.org/XML/split")
    let SplitAccount        = XName.Get("account", "http://www.gnucash.org/XML/split")
    let SplitValue          = XName.Get("value", "http://www.gnucash.org/XML/split")
    let SplitQuantity       = XName.Get("quantity", "http://www.gnucash.org/XML/split")

    let TransactionId           = XName.Get("id", "http://www.gnucash.org/XML/trn")
    let TransactionCurrency     = XName.Get("currency", "http://www.gnucash.org/XML/trn")
    let TransactionPosted       = XName.Get("date-posted", "http://www.gnucash.org/XML/trn")
    let TransactionEntered      = XName.Get("date-entered", "http://www.gnucash.org/XML/trn")
    let TransactionDescription  = XName.Get("description", "http://www.gnucash.org/XML/trn")
    let TransactionSplits       = XName.Get("splits", "http://www.gnucash.org/XML/trn")

    let Element = fun (name:XName) -> fun (x:XElement) -> x.Element(name)
    let Elements = fun (name:XName) -> fun (x:XElement) -> x.Elements(name)
    let Value = fun (name:XName) -> fun (x:XElement) -> x.Element(name).Value
    let AllElements = fun (x:XElement) -> x.Elements()

