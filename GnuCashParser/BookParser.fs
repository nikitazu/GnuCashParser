namespace GnuCashParser

open System
open System.Collections.Generic
open System.Linq
open System.Xml.Linq
open Xml

type Book(id, accounts) =
    member this.Id = id
    member this.Accounts = accounts

type BookParser() = 
    member this.Parse(xml) =
        let parseAccount = fun (xaccount : XElement) ->
            let accountParser = new AccountParser()
            accountParser.ParseElement(xaccount)

        let xbook       = XDocument.Parse(xml).Root |> Element XBook
        let id          = xbook |> Value BookId |> Guid.Parse
        let xaccounts   = xbook |> Elements XAccount |> Seq.map parseAccount

        new Book(
            id,
            xaccounts.ToList())

