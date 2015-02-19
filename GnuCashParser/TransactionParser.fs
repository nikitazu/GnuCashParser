namespace GnuCashParser

open System
open System.Collections.Generic
open System.Globalization
open System.Linq
open System.Xml.Linq

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
        let parseMoney = fun (value : string) ->
            let parts = value.Split('/')
            let divisible = Decimal.Parse(parts.[0])
            let divisor = Decimal.Parse(parts.[1])
            divisible / divisor
            
        let parseSplit = fun (xsplit : XElement) ->
            let id          = xsplit.Element(XNames.SplitId).Value         |> Guid.Parse
            let accountId   = xsplit.Element(XNames.SplitAccount).Value    |> Guid.Parse
            let value       = xsplit.Element(XNames.SplitValue).Value      |> parseMoney
            let quantity    = xsplit.Element(XNames.SplitQuantity).Value   |> parseMoney
            new TransactionSplit(id, accountId, value, quantity)

        let parseDate = fun (dateString : string) ->
            DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm:ss zzz", CultureInfo.InvariantCulture)

        let xtransaction = XElement.Parse(xml)
        
        let id          = xtransaction.Element(XNames.TransactionId).Value      |> Guid.Parse
        let posted      = xtransaction.Element(XNames.TransactionPosted).Value  |> parseDate
        let entered     = xtransaction.Element(XNames.TransactionEntered).Value |> parseDate
        let description = xtransaction.Element(XNames.TransactionDescription).Value
        let currency    = xtransaction.Element(XNames.TransactionCurrency).Element(XNames.CommodityId).Value
        let xsplits     = xtransaction.Element(XNames.TransactionSplits).Elements() |> Seq.map(parseSplit)

        new Transaction(
            id, currency, posted, entered, description, xsplits.ToList())

