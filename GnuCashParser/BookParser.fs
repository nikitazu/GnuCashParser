namespace GnuCashParser

open System
open System.Collections.Generic
open System.Linq
open System.Xml.Linq
open Xml

type Book(id, accounts, transactions) =
    member this.Id = id
    member this.Accounts = accounts
    member this.Transactions = transactions

module BookParser =
    let Parse(xml) =
        let xbook           = DocumentRoot xml                  |> Element XBook
        let id              = xbook |> Value BookId             |> Guid.Parse
        let xaccounts       = xbook |> Elements XAccount        |> Seq.map AccountParser.ParseElement
        let xtransactions   = xbook |> Elements XTransaction    |> Seq.map TransactionParser.ParseElement

        new Book(id, xaccounts.ToList(), xtransactions.ToList())

