namespace GnuCashParser

open System
open System.Xml.Linq
open Xml

type Account(name : String, aType : String, id : Guid, parentId : Nullable<Guid>, commodity : String) =
    member this.Name = name
    member this.Type = aType
    member this.Id = id
    member this.ParentId = parentId
    member this.Commodity = commodity

type AccountParser() = 
    member this.Parse(xml) =
        XElement.Parse xml |> this.ParseElement

    member this.ParseElement(xaccount : XElement) =
        let name    = xaccount |> Value AccountName
        let aType   = xaccount |> Value AccountType
        let id      = xaccount |> Value AccountId |> Guid.Parse

        let commodityId = 
            match xaccount |> Element AccountCommodity with
            | null -> ""
            | commodity -> commodity |> Value CommodityId

        let parentId = 
            match xaccount |> Element AccountParent with
            | null -> new Nullable<Guid>()
            | parent -> new Nullable<Guid>(parent.Value |> Guid.Parse)

        new Account(name, aType, id, parentId, commodityId)
