namespace rec HuffmanFs.Core

open System.Runtime.CompilerServices

[<assembly: InternalsVisibleTo("HuffmanFs.Tests")>]
do ()

type internal HuffmanTree<'T> =
    | Leaf of 'T
    | Node of HuffmanNode<'T>

    static member createLeaf<'T>(value: 'T) = Leaf value

    static member createNode<'T> (left: HuffmanTree<'T>) (right: HuffmanTree<'T>) = Node(HuffmanNode.create left right)

type internal HuffmanNode<'T> = {
    Left: HuffmanTree<'T>
    Right: HuffmanTree<'T>
} with

    static member create<'T> (left: HuffmanTree<'T>) (right: HuffmanTree<'T>) = { Left = left; Right = right }
