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

type BookParser() = 
    member this.Parse(xml) =
        let parseAccount = fun (xaccount : XElement) ->
            let accountParser = new AccountParser()
            accountParser.ParseElement(xaccount)

        let parseTransaction = fun (xtransaction : XElement) ->
            let transactionParser = new TransactionParser()
            transactionParser.ParseElement(xtransaction)

        let xbook       = XDocument.Parse(xml).Root |> Element XBook
        let id          = xbook |> Value BookId |> Guid.Parse
        let xaccounts   = xbook |> Elements XAccount |> Seq.map parseAccount
        let xtransactions = xbook |> Elements XTransaction |> Seq.map parseTransaction

        new Book(id, xaccounts.ToList(), xtransactions.ToList())

