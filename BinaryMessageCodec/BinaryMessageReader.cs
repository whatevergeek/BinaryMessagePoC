using System;
using System.IO;

namespace BinaryMessageCodec
{
    public class BinaryMessageReader
    {
        private const byte Terminator = 0xFF;
        private readonly BinaryReader _reader;

        public BinaryMessageReader(byte[] data)
        {
            var stream = new MemoryStream(data);
            _reader = new BinaryReader(stream);
            int length = _reader.ReadInt32();
        }

        public int ReadInt() => _reader.ReadInt32();
        public string ReadString() => _reader.ReadString();
        public bool ReadBool() => _reader.ReadBoolean();
        public float ReadFloat() => _reader.ReadSingle();

        public DateTime ReadDateTime()
        {
            long unixSeconds = _reader.ReadInt64();
            return DateTimeOffset.FromUnixTimeSeconds(unixSeconds).UtcDateTime;
        }

        public void ValidateTerminator()
        {
            byte t = _reader.ReadByte();
            if (t != Terminator)
                throw new InvalidDataException("Invalid message terminator.");
        }
    }
}
