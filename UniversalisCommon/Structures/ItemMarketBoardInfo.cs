using System;

namespace Dalamud.Game.Network.Structures
{
    public struct ItemMarketBoardInfo
    {
        public uint Sequence;
        public uint ContainerId;
        public uint SlotId;
        public uint PricePerUnit;

        public static ItemMarketBoardInfo Read(byte[] data)
        {
            return new ItemMarketBoardInfo
            {
                Sequence = BitConverter.ToUInt32(data, 0x0),
                ContainerId = BitConverter.ToUInt32(data, 0x4),
                SlotId = BitConverter.ToUInt32(data, 0x8),
                PricePerUnit = BitConverter.ToUInt32(data, 0x10),
            };
        }
    }
}