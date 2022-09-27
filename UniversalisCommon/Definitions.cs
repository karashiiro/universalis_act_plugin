using Newtonsoft.Json;
using System;
using System.Net;

namespace UniversalisCommon
{
    public class Definitions
    {
        public short ClientTrigger { get; set; }
        public short PlayerSpawn { get; set; }
        public short PlayerSetup { get; set; }
        [Obsolete] public short MarketBoardItemRequestStart { get; set; }
        [Obsolete] public short MarketBoardOfferings { get; set; }
        [Obsolete] public short MarketBoardHistory { get; set; }
        [Obsolete] public short MarketTaxRates { get; set; }
        [Obsolete] public short ContentIdNameMapResp { get; set; }

#pragma warning disable CS0612
        [JsonIgnore] public short MarketBoardItemListingCount => MarketBoardItemRequestStart;
        [JsonIgnore] public short MarketBoardItemListing => MarketBoardOfferings;
        [JsonIgnore] public short MarketBoardItemListingHistory => MarketBoardHistory;
        [JsonIgnore] public short ResultDialog => MarketTaxRates;
        [JsonIgnore] public short CharaNameReq => ContentIdNameMapResp;
#pragma warning restore CS0612

        private static readonly Uri DefinitionStoreUrl = new Uri(RemoteDataLocations.OpcodeDefinitions);

        private Definitions()
        {
        }

        public static Definitions Get()
        {
            using var client = new WebClient();
            try
            {
                var definitionJson = client.DownloadString(DefinitionStoreUrl);
                var deserializedDefinition = JsonConvert.DeserializeObject<Definitions>(definitionJson);

                return deserializedDefinition;
            }
            catch (WebException exc)
            {
                throw new Exception("Could not get definitions for Universalis.", exc);
            }
        }
    }
}