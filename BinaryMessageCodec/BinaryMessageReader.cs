using System;
using System.IO;

namespace BinaryMessageCodec
{
    /// <summary>
    /// Reads binary encoded messages created by <see cref="BinaryMessageWriter"/>.
    /// </summary>
    public class BinaryMessageReader
    {
        private const byte Terminator = 0xFF;
        private readonly BinaryReader _reader;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryMessageReader"/> class.
        /// </summary>
        /// <param name="data">The binary data to read from.</param>
        public BinaryMessageReader(byte[] data)
        {
            var stream = new MemoryStream(data);
            _reader = new BinaryReader(stream);
            int length = _reader.ReadInt32();
        }

        /// <summary>Reads an integer from the binary message.</summary>
        /// <returns>The integer value.</returns>
        public int ReadInt() => _reader.ReadInt32();
        
        /// <summary>Reads a string from the binary message.</summary>
        /// <returns>The string value.</returns>
        public string ReadString() => _reader.ReadString();
        
        /// <summary>Reads a boolean from the binary message.</summary>
        /// <returns>The boolean value.</returns>
        public bool ReadBool() => _reader.ReadBoolean();
        
        /// <summary>Reads a float from the binary message.</summary>
        /// <returns>The float value.</returns>
        public float ReadFloat() => _reader.ReadSingle();

        /// <summary>Reads a DateTime from the binary message.</summary>
        /// <returns>The DateTime value in UTC.</returns>
        public DateTime ReadDateTime()
        {
            long unixSeconds = _reader.ReadInt64();
            return DateTimeOffset.FromUnixTimeSeconds(unixSeconds).UtcDateTime;
        }

        /// <summary>
        /// Validates that the message ends with the expected terminator byte.
        /// </summary>
        /// <exception cref="InvalidDataException">Thrown when the terminator is invalid.</exception>
        public void ValidateTerminator()
        {
            byte t = _reader.ReadByte();
            if (t != Terminator)
                throw new InvalidDataException("Invalid message terminator.");
        }
    }
}
