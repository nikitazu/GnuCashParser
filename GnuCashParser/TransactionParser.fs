namespace GnuCashParser

open System
open System.Collections.Generic
open System.Globalization
open System.Linq
open System.Xml.Linq
open Xml

type TransactionSplit(id : Guid, accountId : Guid, value : Decimal, quantity : Decimal) =
    member this.Id = id
    member this.AccountId = accountId
    member this.Value = value
    member this.Quantity = quantity

type Transaction(id : Guid, currency : String, posted : DateTime, entered : DateTime, description : String, splits : List<TransactionSplit>) =
    member this.Id = id
    member this.Currency = currency
    member this.Posted = posted
    member this.Entered = entered
    member this.Description = description
    member this.Splits = splits

type TransactionParser() = 
    member this.Parse(xml) =
        xml |> XElement.Parse |> this.ParseElement

    member this.ParseElement(xtransaction : XElement) =
        let parseMoney = fun (value : string) ->
            let parts       = value.Split '/'
            let divisible   = parts.[0] |> Decimal.Parse
            let divisor     = parts.[1] |> Decimal.Parse
            divisible / divisor
            
        let parseSplit = fun (xsplit : XElement) ->
            let id          = xsplit |> Value SplitId       |> Guid.Parse
            let accountId   = xsplit |> Value SplitAccount  |> Guid.Parse
            let value       = xsplit |> Value SplitValue    |> parseMoney
            let quantity    = xsplit |> Value SplitQuantity |> parseMoney
            new TransactionSplit(id, accountId, value, quantity)

        let parseDate = fun (dateString : string) ->
            DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm:ss zzz", CultureInfo.InvariantCulture)

        let id          = xtransaction |> Value TransactionId           |> Guid.Parse
        let posted      = xtransaction |> Value TransactionPosted       |> parseDate
        let entered     = xtransaction |> Value TransactionEntered      |> parseDate
        let description = xtransaction |> Value TransactionDescription
        let currency    = xtransaction |> Element TransactionCurrency   |> Value CommodityId
        let xsplits     = xtransaction |> Element TransactionSplits     |> AllElements |> Seq.map parseSplit

        new Transaction(id, currency, posted, entered, description, xsplits.ToList())

