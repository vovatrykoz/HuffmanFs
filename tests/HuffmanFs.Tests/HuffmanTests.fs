namespace HuffmanFs.Tests

open HuffmanFs.Core
open NUnit.Framework
open FsCheck.NUnit

module internal ``Huffman Tree Tests`` =
    //
    [<Property>]
    let ``Can create a leaf node`` (value: byte) =
        let expected = Leaf value
        let actual = HuffmanTree.createLeaf value

        Assert.That(actual, Is.EqualTo expected)

    [<Property>]
    let ``Can create a node by itself`` (left: HuffmanTree<byte>) (right: HuffmanTree<byte>) =
        let expected = { Left = left; Right = right }
        let actual = HuffmanNode.create left right

        Assert.That(actual, Is.EqualTo expected)

    [<Property>]
    let ``Can create a tree node`` (left: HuffmanTree<byte>) (right: HuffmanTree<byte>) =
        let expected = Node { Left = left; Right = right }
        let actual = HuffmanTree.createNode left right

        Assert.That(actual, Is.EqualTo expected)

module internal ``Huffman Helpers Tests`` =
    open System
    open System.Collections

    [<Property>]
    let ``Can correctly calculate element frequency`` (elements: byte array) =
        let expected = elements |> Array.countBy id |> dict

        let span = ReadOnlySpan<byte> elements
        let actual = Huffman.countElementFrequency span

        Assert.That(actual, Is.EqualTo<IEnumerable> expected)
