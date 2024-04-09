module Kaya.Tests

open Xunit
open Swensen.Unquote

[<Fact>]
let ``My test`` () = test <@ 1 + 3 = 2 @>
