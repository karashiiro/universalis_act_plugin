using System.Collections.Generic;
using Dalamud.Game.Network.Structures;

namespace UniversalisCommon
{
    public class RetainerContext
    {
        private readonly List<MarketBoardCurrentOfferings.MarketBoardItemListing> _listings;

        public RetainerContext()
        {
            _listings = new List<MarketBoardCurrentOfferings.MarketBoardItemListing>();
        }

        public void AddListing(MarketBoardCurrentOfferings.MarketBoardItemListing listing)
        {
            _listings.Add(listing);
        }

        public IReadOnlyList<MarketBoardCurrentOfferings.MarketBoardItemListing> GetListings()
        {
            return _listings;
        }
    }
}