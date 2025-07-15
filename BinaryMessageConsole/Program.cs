using System;
using BinaryMessageCodec;

class Program
{
    static void Main()
    {
        var writer = new BinaryMessageWriter();
        writer.Write("MSFT");                   // Symbol
        writer.Write(503.02f);                  // Price
        writer.Write(100);                      // Quantity
        writer.Write(true);                     // Side: Buy
        writer.Write(DateTime.UtcNow);          // Timestamp

        byte[] fixStyleMessage = writer.GetMessage();

        byte[] data = writer.GetMessage();

        var reader = new BinaryMessageReader(fixStyleMessage);
        string symbol = reader.ReadString();
        float price = reader.ReadFloat();
        int qty = reader.ReadInt();
        bool isBuy = reader.ReadBool();
        DateTime ts = reader.ReadDateTime();
        reader.ValidateTerminator();

        string sideLabel = isBuy ? "BUY" : "SELL";
        Console.WriteLine($@"
        Sample-Tick:
        Symbol     : {symbol}
        Side       : {sideLabel}
        Price      : {price}
        Quantity   : {qty}
        Timestamp  : {ts:O}");
    }
}
