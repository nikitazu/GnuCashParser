namespace GnuCashParser

open System
open System.Xml.Linq

type Account(name : String, aType : String, id : Guid, parentId : Nullable<Guid>, commodity : String) =
    member this.Name = name
    member this.Type = aType
    member this.Id = id
    member this.ParentId = parentId
    member this.Commodity = commodity

type AccountParser() = 
    member this.Parse(xml) =
        let xaccount = XElement.Parse(xml)
        this.ParseElement(xaccount)

    member this.ParseElement(xaccount : XElement) =
        let name    = xaccount.Element(XNames.AccountName).Value
        let aType   = xaccount.Element(XNames.AccountType).Value
        let id      = xaccount.Element(XNames.AccountId).Value |> Guid.Parse

        let commodity = xaccount.Element(XNames.AccountCommodity)
        let commodityId =
            if commodity = null
            then ""
            else commodity.Element(XNames.CommodityId).Value

        let xparent = xaccount.Element(XNames.AccountParent)
        let parentId = 
            if xparent = null 
            then new Nullable<Guid>() 
            else new Nullable<Guid>(Guid.Parse(xparent.Value))

        new Account(name, aType, id, parentId, commodityId)
