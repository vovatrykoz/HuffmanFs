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

    let buildHuffmanTree (frequency: Dictionary<byte, int>) =
        if frequency.Count = 0 then
            invalidArg (nameof frequency) "The frequency collection of elements was empty"

        let priorityQueue = PriorityQueue<HuffmanTree<byte> * int, int>()

        for KeyValue(k, v) in frequency do
            priorityQueue.Enqueue((HuffmanTree.createLeaf k, v), v)

        while priorityQueue.Count >= 2 do
            let left, leftWeight = priorityQueue.Dequeue()
            let right, rightWeight = priorityQueue.Dequeue()
            let newNode = HuffmanTree.createNode left right
            let newWeight = leftWeight + rightWeight

            priorityQueue.Enqueue((newNode, newWeight), newWeight)

        let tree, _ = priorityQueue.Dequeue()
        tree
