using System;
using System.IO;

namespace BinaryMessageCodec
{
    public class BinaryMessageWriter
    {
        private const byte Terminator = 0xFF;
        private readonly MemoryStream _stream = new();
        private readonly BinaryWriter _writer;

        public BinaryMessageWriter()
        {
            _writer = new BinaryWriter(_stream);
            _writer.Write(0); // Placeholder for length
        }

        public void Write(int value) => _writer.Write(value);
        public void Write(string value) => _writer.Write(value);
        public void Write(bool value) => _writer.Write(value);
        public void Write(float value) => _writer.Write(value);

        public void Write(DateTime value)
        {
            long unixSeconds = new DateTimeOffset(value).ToUnixTimeSeconds();
            _writer.Write(unixSeconds);
        }

        public byte[] GetMessage()
        {
            _writer.Write(Terminator);
            int length = (int)_stream.Length;
            _stream.Position = 0;
            _writer.Write(length);
            return _stream.ToArray();
        }
    }
}
