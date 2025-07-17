using System;
using System.IO;

namespace BinaryMessageCodec
{
    /// <summary>
    /// Writes data in binary format that can be read by <see cref="BinaryMessageReader"/>.
    /// </summary>
    public class BinaryMessageWriter
    {
        private const byte Terminator = 0xFF;
        private readonly MemoryStream _stream = new();
        private readonly BinaryWriter _writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryMessageWriter"/> class.
        /// </summary>
        public BinaryMessageWriter()
        {
            _writer = new BinaryWriter(_stream);
            _writer.Write(0); // Placeholder for length
        }

        /// <summary>Writes an integer to the binary message.</summary>
        /// <param name="value">The integer value to write.</param>
        public void Write(int value) => _writer.Write(value);
        
        /// <summary>Writes a string to the binary message.</summary>
        /// <param name="value">The string value to write.</param>
        public void Write(string value) => _writer.Write(value);
        
        /// <summary>Writes a boolean to the binary message.</summary>
        /// <param name="value">The boolean value to write.</param>
        public void Write(bool value) => _writer.Write(value);
        
        /// <summary>Writes a float to the binary message.</summary>
        /// <param name="value">The float value to write.</param>
        public void Write(float value) => _writer.Write(value);

        /// <summary>Writes a DateTime to the binary message.</summary>
        /// <param name="value">The DateTime value to write.</param>
        public void Write(DateTime value)
        {
            long unixSeconds = new DateTimeOffset(value).ToUnixTimeSeconds();
            _writer.Write(unixSeconds);
        }

        /// <summary>
        /// Finalizes the message and returns the binary data.
        /// </summary>
        /// <returns>The complete binary message as a byte array.</returns>
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
