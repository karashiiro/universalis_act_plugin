using System;

namespace Dalamud.Game.Network.Structures
{
    public struct ItemMarketBoardInfo
    {
        public ushort Container;
        public ushort Slot;
        public uint PricePerUnit;

        public static ItemMarketBoardInfo Read(byte[] data)
        {
            return new ItemMarketBoardInfo
            {
                Container = BitConverter.ToUInt16(data, 0x0),
                Slot = BitConverter.ToUInt16(data, 0x8),
                PricePerUnit = BitConverter.ToUInt32(data, 0x10),
            };
        }
    }
}