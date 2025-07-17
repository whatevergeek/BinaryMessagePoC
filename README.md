# BinaryMessageCodec

A simple library for binary message encoding and decoding.

## Features

- Efficient binary serialization and deserialization
- Support for common data types (int, string, bool, float, DateTime)
- Message termination validation

## Usage

```csharp
// Writing a binary message
var writer = new BinaryMessageWriter();
writer.Write(42);                   // Write an integer
writer.Write("Hello, world!");      // Write a string
writer.Write(true);                 // Write a boolean
writer.Write(3.14f);                // Write a float
writer.Write(DateTime.UtcNow);      // Write a DateTime
byte[] messageData = writer.GetMessage();

// Reading a binary message
var reader = new BinaryMessageReader(messageData);
int intValue = reader.ReadInt();
string stringValue = reader.ReadString();
bool boolValue = reader.ReadBool();
float floatValue = reader.ReadFloat();
DateTime dateTimeValue = reader.ReadDateTime();
reader.ValidateTerminator();
```

## Installation

```
dotnet add package BinaryMessageCodec
```