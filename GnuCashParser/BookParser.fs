namespace GnuCashParser

open System
open System.Collections.Generic
open System.Linq
open System.Xml.Linq

type Book(id, accounts) =
    member this.Id = id
    member this.Accounts = accounts

type BookParser() = 
    member this.Parse(xml) =
        let parseAccount = fun (xaccount : XElement) ->
            let accountParser = new AccountParser()
            accountParser.ParseElement(xaccount)

        let xbook       = XDocument.Parse(xml).Root.Element(XNames.Book)
        let id          = xbook.Element(XNames.BookId).Value |> Guid.Parse
        let xaccounts   = xbook.Elements(XNames.Account)

        new Book(
            id,
            xaccounts.Select(parseAccount).ToList())

