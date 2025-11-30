namespace HuffmanFs.Core

module internal Huffman =
    open System
    open System.Collections.Generic

    let countElementFrequency (elements: ReadOnlySpan<byte>) =
        let frequency = Dictionary<byte, int>()

        for i in 0 .. (elements.Length - 1) do
            let currentByte = elements.[i]
            frequency.[currentByte] <- frequency.GetValueOrDefault currentByte + 1

        frequency
